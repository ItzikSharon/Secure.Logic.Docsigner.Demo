// See https://aka.ms/new-console-template for more information


using com.slg.docsigner.demo;

Console.WriteLine("DocSigner API Demo");

DocSignerAPIConnector.Settings.BaseURL = "https://docsigner.co.il:6444/api/ext/v1";
DocSignerAPIConnector.Settings.APIID = "65a005199d6a8fd4ad963ef7";
DocSignerAPIConnector.Settings.APIKey = "eyJDbGFpbXMiOlt7IktleSI6ImFwaV9jb25uZWN0b3JfaWQiLCJWYWx1ZSI6IjY1YTAwNTE5OWQ2YThmZDRhZDk2M2VmNyJ9LHsiS2V5IjoidGVuYW50X2lkIiwiVmFsdWUiOiJpdHppa19zZWN1cmVsb2dpY19jb19pbCJ9XSwiQ3JlYXRpb25EYXRlIjoiMjAyNC0wMS0xMVQxNzoxMToyMS4wNTY5NDYrMDI6MDAiLCJMaWZlVGltZVNlY29uZHMiOjB9";


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







