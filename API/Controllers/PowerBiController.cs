
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
 public class PoserBiController : BaseApiController
    {}}

// private async Task<string> GetPowerBIAccessToken(PowerBISettings powerBISettings)
// {
//    var client = new HttpClient();
    
//         var form = new Dictionary<string, string>();
//         form["grant_type"] = "password";
//         form["resource"] = powerBISettings.ResourceUrl;
//         form["username"] = powerBISettings.UserName;
//         form["password"] = powerBISettings.Password;
//         form["client_id"] = powerBISettings.ApplicationId.ToString();
//         form["client_secret"] = powerBISettings.ApplicationSecret;
//         form["scope"] = "openid";
 
//         client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
 
//         using (var formContent = new FormUrlEncodedContent(form))
//         using (var response = await client.PostAsync(powerBISettings.AuthorityUrl, formContent))
//         {
//             var body = await response.Content.ReadAsStringAsync();
//             var jsonBody = JObject.Parse(body); 
            
//             var errorToken = jsonBody.SelectToken("error");
//             if(errorToken != null)
//             {
//                 throw new Exception(errorToken.Value<string>());
//             }
 
//             return jsonBody.SelectToken("access_token").Value<string>();
//         }}

    
//     public async Task<IActionResult> Report([FromServices]PowerBISettings powerBISettings)
// {
//     var result = new PowerBIEmbedConfig { Username = powerBISettings.UserName };
//     var accessToken = await GetPowerBIAccessToken(powerBISettings);
//     var tokenCredentials = new TokenCredentials(accessToken, "Bearer");
 
//     using (var client = new PowerBIClient(new Uri(powerBISettings.ApiUrl), tokenCredentials))
//     {
//         var workspaceId = powerBISettings.WorkspaceId.ToString();
//         var reportId = powerBISettings.ReportId.ToString();
//         var report = await client.Reports.GetReportInGroupAsync(workspaceId, reportId);
//         var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
//         var tokenResponse = await client.Reports.GenerateTokenAsync(workspaceId, reportId, generateTokenRequestParameters);
 
//         result.EmbedToken = tokenResponse;
//         result.EmbedUrl = report.EmbedUrl;
//         result.Id = report.Id;
//     }
 
//     return View(result);
// }
  