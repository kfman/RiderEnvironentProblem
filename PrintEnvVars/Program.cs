// See https://aka.ms/new-console-template for more information

using PrintEnvVars;

foreach (System.Collections.DictionaryEntry env in System.Environment.GetEnvironmentVariables())
    Console.WriteLine($"{env.Key}={env.Value}");

var result = new EncryptionDemo().Encrypt("This is a test...");
Console.WriteLine(result);
