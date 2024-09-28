using System.ComponentModel;

namespace Common.Enums
{
    public enum Headers
    {
        [Description("platform-type")]
        Platform = 0,

        [Description("app-version")]
        App = 1,

        [Description("os-version")]
        OS = 2,

        [Description("device-model")]
        Device = 3,

        [Description("device-id")]
        Id = 4,

        [Description("user-name")]
        User = 5,

    }


    public enum AuthHeaders
    {
        [Description("x-auth-key")]
        AuthKey = 0,

        [Description("x-idempotence-key")]
        IdempotenceKey = 1
    }

	public enum WebhookHeaders
	{
		[Description("x-webhook-api-key")]
		WebhookApiKey = 0
	}
}
