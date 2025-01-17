// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    /// <summary> The RoleAssignments service client. </summary>
    public partial class RoleAssignmentsClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }
        private HttpPipeline _pipeline;
        private readonly string[] AuthorizationScopes = { "https://dev.azuresynapse.net/.default" };
        private readonly TokenCredential _tokenCredential;
        private Uri endpoint;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Initializes a new instance of RoleAssignmentsClient for mocking. </summary>
        protected RoleAssignmentsClient()
        {
        }

        /// <summary> Initializes a new instance of RoleAssignmentsClient. </summary>
        /// <param name="endpoint"> The workspace development endpoint, for example https://myworkspace.dev.azuresynapse.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public RoleAssignmentsClient(Uri endpoint, TokenCredential credential, AccessControlClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new AccessControlClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            this.endpoint = endpoint;
            apiVersion = options.Version;
        }

        /// <summary> Check if the given principalId has access to perform list of actions at a given scope. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   subject: {
        ///     principalId: SubjectInfoPrincipalId (required),
        ///     groupIds: [SubjectInfoGroupIdsItem]
        ///   } (required),
        ///   actions: [
        ///     {
        ///       id: string (required),
        ///       isDataAction: boolean (required)
        ///     }
        ///   ] (required),
        ///   scope: string (required)
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   accessDecisions: [
        ///     {
        ///       accessDecision: string,
        ///       actionId: string,
        ///       roleAssignment: {
        ///         id: string,
        ///         roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///         principalId: RoleAssignmentDetailsPrincipalId,
        ///         scope: string,
        ///         principalType: string
        ///       }
        ///     }
        ///   ]
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> CheckPrincipalAccessAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateCheckPrincipalAccessRequest(content);
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("RoleAssignmentsClient.CheckPrincipalAccess");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Check if the given principalId has access to perform list of actions at a given scope. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   subject: {
        ///     principalId: SubjectInfoPrincipalId (required),
        ///     groupIds: [SubjectInfoGroupIdsItem]
        ///   } (required),
        ///   actions: [
        ///     {
        ///       id: string (required),
        ///       isDataAction: boolean (required)
        ///     }
        ///   ] (required),
        ///   scope: string (required)
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   accessDecisions: [
        ///     {
        ///       accessDecision: string,
        ///       actionId: string,
        ///       roleAssignment: {
        ///         id: string,
        ///         roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///         principalId: RoleAssignmentDetailsPrincipalId,
        ///         scope: string,
        ///         principalType: string
        ///       }
        ///     }
        ///   ]
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response CheckPrincipalAccess(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateCheckPrincipalAccessRequest(content);
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("RoleAssignmentsClient.CheckPrincipalAccess");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateCheckPrincipalAccessRequest(RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/checkAccessSynapseRbac", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        /// <summary> List role assignments. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   count: number,
        ///   value: [
        ///     {
        ///       id: string,
        ///       roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///       principalId: RoleAssignmentDetailsPrincipalId,
        ///       scope: string,
        ///       principalType: string
        ///     }
        ///   ]
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleId"> Synapse Built-In Role Id. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="continuationToken"> Continuation token. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> ListRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateListRoleAssignmentsRequest(roleId, principalId, scope, continuationToken);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.ListRoleAssignments");
            scope0.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> List role assignments. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   count: number,
        ///   value: [
        ///     {
        ///       id: string,
        ///       roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///       principalId: RoleAssignmentDetailsPrincipalId,
        ///       scope: string,
        ///       principalType: string
        ///     }
        ///   ]
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleId"> Synapse Built-In Role Id. </param>
        /// <param name="principalId"> Object ID of the AAD principal or security-group. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="continuationToken"> Continuation token. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateListRoleAssignmentsRequest(roleId, principalId, scope, continuationToken);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.ListRoleAssignments");
            scope0.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateListRoleAssignmentsRequest(string roleId, string principalId, string scope, string continuationToken)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/roleAssignments", false);
            uri.AppendQuery("api-version", apiVersion, true);
            if (roleId != null)
            {
                uri.AppendQuery("roleId", roleId, true);
            }
            if (principalId != null)
            {
                uri.AppendQuery("principalId", principalId, true);
            }
            if (scope != null)
            {
                uri.AppendQuery("scope", scope, true);
            }
            request.Uri = uri;
            if (continuationToken != null)
            {
                request.Headers.Add("x-ms-continuation", continuationToken);
            }
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> Create role assignment. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   roleId: RoleAssignmentRequestRoleId (required),
        ///   principalId: RoleAssignmentRequestPrincipalId (required),
        ///   scope: string (required),
        ///   principalType: string
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///   principalId: RoleAssignmentDetailsPrincipalId,
        ///   scope: string,
        ///   principalType: string
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> CreateRoleAssignmentAsync(string roleAssignmentId, RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateCreateRoleAssignmentRequest(roleAssignmentId, content);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.CreateRoleAssignment");
            scope0.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Create role assignment. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   roleId: RoleAssignmentRequestRoleId (required),
        ///   principalId: RoleAssignmentRequestPrincipalId (required),
        ///   scope: string (required),
        ///   principalType: string
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///   principalId: RoleAssignmentDetailsPrincipalId,
        ///   scope: string,
        ///   principalType: string
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response CreateRoleAssignment(string roleAssignmentId, RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateCreateRoleAssignmentRequest(roleAssignmentId, content);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.CreateRoleAssignment");
            scope0.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateCreateRoleAssignmentRequest(string roleAssignmentId, RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/roleAssignments/", false);
            uri.AppendPath(roleAssignmentId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        /// <summary> Get role assignment by role assignment Id. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///   principalId: RoleAssignmentDetailsPrincipalId,
        ///   scope: string,
        ///   principalType: string
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetRoleAssignmentByIdAsync(string roleAssignmentId, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateGetRoleAssignmentByIdRequest(roleAssignmentId);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.GetRoleAssignmentById");
            scope0.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Get role assignment by role assignment Id. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   roleDefinitionId: RoleAssignmentDetailsRoleDefinitionId,
        ///   principalId: RoleAssignmentDetailsPrincipalId,
        ///   scope: string,
        ///   principalType: string
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response GetRoleAssignmentById(string roleAssignmentId, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateGetRoleAssignmentByIdRequest(roleAssignmentId);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.GetRoleAssignmentById");
            scope0.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateGetRoleAssignmentByIdRequest(string roleAssignmentId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/roleAssignments/", false);
            uri.AppendPath(roleAssignmentId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> Delete role assignment by role assignment Id. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateDeleteRoleAssignmentByIdRequest(roleAssignmentId, scope);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.DeleteRoleAssignmentById");
            scope0.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                        case 204:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Delete role assignment by role assignment Id. </summary>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [ErrorResponse],
        ///     additionalInfo: [
        ///       {
        ///         type: string,
        ///         info: AnyObject
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="roleAssignmentId"> The ID of the role assignment. </param>
        /// <param name="scope"> Scope of the Synapse Built-in Role. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateDeleteRoleAssignmentByIdRequest(roleAssignmentId, scope);
            RequestOptions.Apply(options, message);
            using var scope0 = _clientDiagnostics.CreateScope("RoleAssignmentsClient.DeleteRoleAssignmentById");
            scope0.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                        case 204:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateDeleteRoleAssignmentByIdRequest(string roleAssignmentId, string scope)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/roleAssignments/", false);
            uri.AppendPath(roleAssignmentId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            if (scope != null)
            {
                uri.AppendQuery("scope", scope, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }
    }
}
