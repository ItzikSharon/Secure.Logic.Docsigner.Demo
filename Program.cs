// See https://aka.ms/new-console-template for more information


using com.slg.docsigner.demo;

Console.WriteLine("DocSigner API Demo");

DocSignerAPIConnector.Settings.BaseURL = "Add here the server base URL";
DocSignerAPIConnector.Settings.APIID = "Add here the API ID";
DocSignerAPIConnector.Settings.APIKey = "Add here the API Key";


//  ----------------------- Call status ---------------
DSAPI_MSG_OUT_STATUS  statusResponse = await DocSignerAPIConnector.STATUS();
Console.WriteLine(ToStringHelper.JSONToString< DSAPI_MSG_OUT_STATUS>(statusResponse));


//  ----------------------- Call APILogin ---------------
DSAPI_MSG_IN_LOGIN apiLoginRequest = new DSAPI_MSG_IN_LOGIN {
    appid = DocSignerAPIConnector.Settings.APIID, 
    appkey = DocSignerAPIConnector.Settings.APIKey
};

DSAPI_MSG_OUT_LOGIN loginResponse = await DocSignerAPIConnector.APILogin(apiLoginRequest);
Console.WriteLine(ToStringHelper.JSONToString<DSAPI_MSG_OUT_CREATE_ENVELOPE>(loginResponse));


//  ----------------------- Call Create Envelope ---------------
DSAPI_MSG_IN_CREATE_ENVELOPE createNewEnvelope = new DSAPI_MSG_IN_CREATE_ENVELOPE{
    name = "My New Envelope",
    is_private = false
};

DSAPI_MSG_OUT_CREATE_ENVELOPE newEnvelopeResponse = await DocSignerAPIConnector.CreateEnvelope(createNewEnvelope, loginResponse.token);
Console.WriteLine(ToStringHelper.JSONToString<DSAPI_MSG_OUT_CREATE_ENVELOPE>(newEnvelopeResponse));







