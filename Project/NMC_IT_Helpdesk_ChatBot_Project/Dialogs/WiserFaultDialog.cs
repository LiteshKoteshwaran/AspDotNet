using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NMC_IT_Helpdesk_ChatBot_Project.Dialogs
{
    [Serializable]
    public class WiserFaultDialog : IDialog<Object>
    {
        public static List<string> ListOfQusetions = new List<string>();
        public static string AdditionalInfo, NosOfUserImpacted, DisplayedErrorMessage, TaskAttemptedWhileIssue, PinAndFullName;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(AdaptiveCards);
            //await New(context);
        }



        private async Task New(IDialogContext context, IAwaitable<object> result)
        {


            //context.Wait(AdaptiveCards);

            await AdaptiveCards(context, result);
        }

        private async Task AdaptiveCards(IDialogContext context, IAwaitable<object> result)
        {
            ListOfQusetions = SqlOperations.GetList("OptionsForFaultWiser");
            {
                try
                {
                    var replyActivity = context.MakeMessage();
                    replyActivity.Attachments.Add(new Microsoft.Bot.Connector.Attachment()
                    {
                        ContentType = "application/vnd.microsoft.card.adaptive",
                        Content = JObject.Parse($@"
                                                    {{
                                                      ""$schema"": ""http://adaptivecards.io/schemas/adaptive-card.json"",
                                                      ""type"": ""AdaptiveCard"",
                                                      ""version"": ""1.0"",
                                                      ""body"": [
                                                        {{
                                                                                ""type"": ""ColumnSet"",
                                                                                ""columns"": [
                                                                                                {{
                                                                                                    ""type"": ""Column"",
                                                                                                    ""items"": 
                                                                                                                [                                                                                                                   
                                                                                                                    {{
                                                                                                                        ""type"": ""TextBlock"",
                                                                                                                        ""size"": ""Medium"",
                                                                                                                        ""weight"": ""Bolder"",
                                                                                                                        ""text"": ""{ListOfQusetions[0]}""
                                                                                                                    }},
                                                                                                                    {{
                        
                                                                                                                        ""type"": ""TextBlock"",
                                                                                                                        ""text"": ""{ ListOfQusetions[1] }"",
                                                                                                                    }},
                                                                                                                    {{
                                                                                                                        ""type"": ""Input.Text"",
                                                                                                                        ""id"": ""PinAndFullName"",
                                                                                                                    }},
                                                                                                                    {{  
                                                                                                                        ""type"": ""TextBlock"",
                                                                                                                        ""text"": ""{ListOfQusetions[2]}"",
                                                                                                                    }},
                                                                                                                    {{
                                                                                                                        ""type"": ""Input.Text"",
                                                                                                                        ""id"": ""TaskAttemptedWhileIssue"",
                                                                                                                    }},
                                                                                                                    {{    
                                                                                                                        ""type"": ""TextBlock"",
                                                                                                                        ""text"": ""{ListOfQusetions[3]}"",
                                                                                                                    }},
                                                                                                                    {{
                                                                                                                        ""type"": ""Input.Text"",
                                                                                                                        ""id"": ""DisplayedErrorMessage"",
                                                                                                                    }},
                                                                                                                    {{                                                                                                              
                                                                                                                        ""type"": ""TextBlock"",
                                                                                                                        ""text"": ""{ListOfQusetions[4]}"",
                                                                                                                    }},
                                                                                                                    {{
                                                                                                                        ""type"": ""Input.Text"",
                                                                                                                        ""id"": ""NosOfUserImpacted"",
                                                                                                                    }},
                                                                                                                    {{                                                                                                              
                                                                                                                        ""type"": ""TextBlock"",
                                                                                                                        ""text"": ""{ListOfQusetions[5]}"",
                                                                                                                    }},
                                                                                                                    {{
                                                                                                                        ""type"": ""Input.Text"",
                                                                                                                        ""id"": ""AdditionalInfo"",
                                                                                                                    }},
                                                                                                                ]
                                                                                                }}
                                                                                             ]
                                                        }}       
                                                                ],
                                                          ""actions"": [
                                                            {{
                                                                ""type"": ""Action.Submit"",
                                                                ""id"": ""submit""
                                                                ""title"": ""Submit"",
                                                                ""data"":{"action":""FaultInfo""}
                                                            }}
                                                                       ]
                                                    }}")
                    });
     

                    await context.PostAsync(replyActivity);
                    //await ReadDataFromAdaptiveCard(context,result);
                    context.Wait(ReadDataFromAdaptiveCard);
                    //WiserRootDialog wiserRootDialog = new WiserRootDialog();
                    //await wiserRootDialog.RiseTicketForFault(context, result);
                    //context.Wait(wiserRootDialog.RiseTicketForFault); 
                }
                catch (Exception e)
                {
                }
            }
        }


        internal async Task ReadDataFromAdaptiveCard(IDialogContext context, IAwaitable<object> result)
        {
            var token = JToken.Parse(result.ToString());

            AdditionalInfo = string.Empty;
            NosOfUserImpacted = string.Empty;
            DisplayedErrorMessage = string.Empty;
            TaskAttemptedWhileIssue = string.Empty;
            PinAndFullName = string.Empty;


            //if (System.Convert.ToBoolean(token["postback"].Value<string>()))
            if (System.Convert.ToBoolean(token["ImBack"].Value<string>()))
            {
                JToken commandToken = JToken.Parse(result.ToString());
                string command = commandToken["action"].Value<string>();

                if (command.ToLowerInvariant() == "PinAndFullName")
                {
                    PinAndFullName = commandToken["PinAndFullName"].Value<string>();
                }
                if (command.ToLowerInvariant() == "TaskAttemptedWhileIssue")
                {
                    TaskAttemptedWhileIssue = commandToken["TaskAttemptedWhileIssue"].Value<string>();
                }
                if (command.ToLowerInvariant() == "DisplayedErrorMessage")
                {
                    DisplayedErrorMessage = commandToken["DisplayedErrorMessage"].Value<string>();
                }
                if (command.ToLowerInvariant() == "NosOfUserImpacted")
                {
                    NosOfUserImpacted = commandToken["NosOfUserImpacted"].Value<string>();
                }
                if (command.ToLowerInvariant() == "AdditionalInfo")
                {
                    AdditionalInfo = commandToken["AdditionalInfo"].Value<string>();
                }

            }

           // await turnContext.SendActivityAsync($"You Selected {selectedcolor}", cancellationToken: cancellationToken);

        }
    }
}

