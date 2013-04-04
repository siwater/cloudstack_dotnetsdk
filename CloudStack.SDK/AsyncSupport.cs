// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

namespace CloudStack.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Provide utility methods to deal with async jobs
    /// </summary>
    public static class AsyncSupport
    {
        /// <summary>
        /// Kick off asynchronous request.
        /// </summary>
        /// <param name="session">Client session</param>
        /// <param name="req">API command</param>
        /// <returns>Asynchronous task job id.</returns>
        public static string StartAsyncJob(Client session, APIRequest req)
        {
            XDocument resp = session.SendRequest(req);

            XElement jobid = resp.Descendants("jobid").FirstOrDefault();

            if (jobid == null || string.IsNullOrEmpty(jobid.Value))
            {
                throw new CloudStackException("Async command failed to return jobid", req.ToString(), resp);
            }
            return jobid.Value;
        }

        /// <summary>
        /// Polls AsyncJob, returns XDocument when job is done.
        /// </summary>
        /// <param name="session">Client connection to CloudStack API</param>
        /// <param name="jobid">Asynchronous job</param>
        /// <returns>Response from async operation.</returns>
        /// <remarks>
        /// Sample result in SampleResponses.QueryAsyncJobResponse
        /// </remarks>
        public static XDocument QueryAsyncJobResult(Client session, string jobid)
        {
            APIRequest req = new SDK.APIRequest("queryAsyncJobResult");
            req.Parameters["jobid"] = jobid;
            return session.SendRequest(req);
        }

        /// <summary>
        /// This method waits for the specified aysnc jon to complete and returns the response.
        /// </summary>
        /// <param name="session">Client session</param>
        /// <param name="jobid">Asynchronous task id</param>
        /// <returns>Returns the raw Xml response</returns>
        /// <exception cref="CloudStackException">Errors reported as exceptions.</exception>
        public static XDocument WaitForAsyncJobResult(Client session, string jobid)
        {
            bool done = false;
            string status = string.Empty;
            XDocument respQuery;
            do
            {
                respQuery = QueryAsyncJobResult(session, jobid);

                XElement statusTag = respQuery.Descendants("jobstatus").FirstOrDefault();
                if (statusTag == null)
                {
                    throw new CloudStackException("Response missing jobstatus for jobid " + jobid, "queryAsyncJobResult", respQuery);
                }
                status = statusTag.Value;

                switch (status)
                {
                    case "2":
                        throw new CloudStackException("Async jobid " + jobid + " ended with error", "WaitForIdFromAsyncJob", respQuery);
                    case "1":
                        return respQuery;
                    case "0":
                        System.Threading.Thread.Sleep(session.CloudPollRate);
                        break;
                    default:
                        done = true;
                        break;
                }
            }
            while (!done);

            throw new CloudStackException("Invalid async job status " + status + " get resulting for async job " + jobid, "WaitForIdFromAsyncJob", respQuery);
        }

        /// <summary>
        /// Run an async job and wait for the result
        /// </summary>
        public static XContainer RunAsyncJob(Client session, APIRequest request)
        {
            string jobid = StartAsyncJob(session, request);
            XDocument response = WaitForAsyncJobResult(session, jobid);
            return response.Descendants("jobresult").FirstOrDefault().FirstNode as XContainer;
        }

        /// <summary>
        ///  Start a job, wait for it to complete and return the resulting resource id
        /// </summary>
        /// <param name="session">the session</param>
        /// <param name="req">the request object</param>
        /// <returns>resource id</returns>
        public static string WaitForResourceIdFromAsyncJob(Client session, APIRequest req)
        {
            string jobid = StartAsyncJob(session, req);
            XDocument asyncResult = WaitForAsyncJobResult(session, jobid);
            XElement id = asyncResult.Descendants("id").FirstOrDefault();

            if (id == null || string.IsNullOrEmpty(id.Value))
            {
                throw new CloudStackException("Failed to obtain new resource id after async job", req.ToString(), asyncResult);
            }
            return id.Value;
        }
    }
}
