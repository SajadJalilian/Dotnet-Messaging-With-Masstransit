namespace ServiceContracts;

public class RabbitMqConfig
{
    public const string Key = "RabbitMQ";

    public string Host { get; set; }

    public string VirtualHost { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool ClusterEnabled { get; set; }

    public string[] ClusterNodes { get; set; }
}