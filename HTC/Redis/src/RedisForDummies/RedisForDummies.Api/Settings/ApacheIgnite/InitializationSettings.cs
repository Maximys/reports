namespace RedisForDummies.Api.Settings.ApacheIgnite
{
    /// <summary>
    /// ��������� ��� ������������� Apache Ignite.
    /// </summary>
    public class InitializationSettings
    {
        /// <summary>
        /// ���� �������, ������������� ��� �������������.
        /// </summary>
        [ConfigurationKeyName("body")]
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// ������ ��� �������������.
        /// </summary>
        [ConfigurationKeyName("url")]
        public Uri InitializationUri { get; set; } = default!;
    }
}
