namespace com.slg.docsigner.demo
{
    public enum DSAPI_RETURN_CODE
    {
        SUCCESS = 0,
        GENERAL_ERROR = 1,
        DOC_ALLREADY_IN_PROCESS = 2,
        DOC_SIGNATURE_NOT_COMPLETED = 3,
        INVALID_DOC_REF_ID = 4,
        INVALID_REQUEST = 5
    }


    public class DSAPI_MESSAGE_OUT
    {
        public int return_code { set; get; } = 0;
        public string return_msg { set; get; } = "success";
        public string extended_msg { set; get; } = string.Empty;
    }


    public class DSAPI_MSG_OUT_STATUS : DSAPI_MESSAGE_OUT
    {
        public string version { set; get; } = string.Empty;
        public string status { set; get; } = string.Empty;
        public string server_id { set; get; } = string.Empty;
    }

    public class DSAPI_MSG_IN_LOGIN
    {
        public string appid { set; get; } = string.Empty;
        public string appkey { set; get; } = string.Empty;
    }
    
    public class DSAPI_MSG_OUT_LOGIN : DSAPI_MESSAGE_OUT
    {
        public string token { set; get; } = string.Empty;
    }


    //Create envelope objects 
    public class DSAPI_SIGNER{
        public string full_name { set; get; } = string.Empty;
        public string email { set; get; } = string.Empty;
        public string id_number { set; get; } = string.Empty;
        public string shared_code { set; get; } = string.Empty;
        public string mobile_phone { set; get; } = string.Empty;
    }

    public enum DSAPI_AUTHENTICATION_METHOD {
        NONE = 0,
    }

    public class DSAPI_RECIPIENT{
        public DSAPI_SIGNER signer { set; get; } = new DSAPI_SIGNER();
        public int authentication_method { set; get; } = (int)DSAPI_AUTHENTICATION_METHOD.NONE;
    }
    public enum DSAPI_ENVELOPE_TYPE
    {
        SEQUENCE = 0,
        PARALLEL = 1
    }
    public enum PRIVACY_AUTHENTICATION_METHOD
    {
        OTP_BY_MAIL = 1,
        OTP_BY_SMS = 2,
        MATCH_ID_NUMBER = 3,
        MATCH_DATE_OF_BIRTH = 4,
        MATCH_IMAGE = 5,
        MATCH_CUSTOM_PASSWORD = 6,
    }


    public class DSAPI_MSG_IN_CREATE_ENVELOPE
    {
        public string name { set; get; } = string.Empty;
        public int type { set; get; } = (int)DSAPI_ENVELOPE_TYPE.PARALLEL;
        public DSAPI_RECIPIENT[] recipients { set; get; } = new DSAPI_RECIPIENT[0];
        public bool is_private { set; get; } = false;
        public int privacy_auth_method { set; get; } = (int)PRIVACY_AUTHENTICATION_METHOD.MATCH_ID_NUMBER;
    }


    public class DSAPI_MSG_OUT_CREATE_ENVELOPE : DSAPI_MESSAGE_OUT{
        public string envelope_id { set; get; } = string.Empty;
    }
}
