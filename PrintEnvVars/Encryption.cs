using Jose;

namespace PrintEnvVars;

public class EncryptionDemo {
    private const JweEncryption Encryption = JweEncryption.A256GCM;
    private const JweCompression Compression = JweCompression.DEF;
    private const JweAlgorithm Algorithm = JweAlgorithm.RSA_OAEP_256;
    private const SerializationMode SerializationMode = Jose.SerializationMode.Compact;


    private const string key =
        "{\n  \"alg\": \"RSA-OAEP-256\",\n  \"e\": \"AQAB\",\n  \"key_ops\": [\n    \"wrapKey\"\n  ],\n  \"kid\": \"vr7cWKGl-g4Wa_CRGowNhAYW_gQb-akMbiigxN0EkDI\",\n  \"kty\": \"RSA\",\n  \"n\": \"zjG3Ic12-kGWiXqVE7CDjICyAb3MpDuhCSM1NTGduy6KqFE-meJjX9lu1MRmquwMu1LNv0Hjx4ksiB0ZL6YjlnqQVMbVdoxnjpcQnFk1j8t1_ndhOatbdCrEZXTm3v_KWpZBm1II8OweN9flLKgk4VM9YyoWMuIqWUnMGLaP8VNsnvcrWBVS_tXtSJG4BF-pJwNQfp6A0rNrsKm_MBF-3uTIXfNrdybjDWu1XrIGR25Y6r8kvNy0yynu9tfhLwBbqbgG8PYktIy6THspdja7QCC2afM0INci1Gj_48YfesLcLbv-jIjLKQn3h9mxKLPYV9-dsRSCZT7HpHPBZ9PcqiuAbfAjpwQKIGYUJkt0GGOhnM-ljKvosGsh4xsCKncJbE2drIHbM1kiGWuGQ_DVaTFxkMEslqqX8_t1AqSdTWD3gqI-02PGc7w1J-iUWQsZDfNPQsihJdg_Icw6IbzGApzNIyAFeSSgJNNJSpY5eXHZB4V0IoGTHFb3jt8wqkDycYiEiTgmLJylXVd_l5DlqXP47HdB5RKLbaZI3iGEMzK98vBl4qWkixDBxDzONa5eWUckB1-vdYYuPksKTqLk1Wlh9a2b75KsOJKcaBOXEHufVIBZy8a-GGbkg21rnGCYU5jmLcPBij0D03PFnD7u0RlPaTe5jWCbF3oYMmQ6Ehc\",\n  \"x5c\": [\n    \"MIIFCTCCAvECBAONrDowDQYJKoZIhvcNAQENBQAwSTELMAkGA1UEBhMCREUxFTATBgNVBAoMDFRlc3RiZWhvZXJkZTEjMCEGA1UEAwwaRklUIENvbm5lY3QgVGVzdHplcnRpZmlrYXQwHhcNMjIwNjI4MTE1MzE1WhcNMzIwNjI1MTE1MzE1WjBJMQswCQYDVQQGEwJERTEVMBMGA1UECgwMVGVzdGJlaG9lcmRlMSMwIQYDVQQDDBpGSVQgQ29ubmVjdCBUZXN0emVydGlmaWthdDCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAM4xtyHNdvpBlol6lROwg4yAsgG9zKQ7oQkjNTUxnbsuiqhRPpniY1/ZbtTEZqrsDLtSzb9B48eJLIgdGS+mI5Z6kFTG1XaMZ46XEJxZNY/Ldf53YTmrW3QqxGV05t7/ylqWQZtSCPDsHjfX5SyoJOFTPWMqFjLiKllJzBi2j/FTbJ73K1gVUv7V7UiRuARfqScDUH6egNKza7CpvzARft7kyF3za3cm4w1rtV6yBkduWOq/JLzctMsp7vbX4S8AW6m4BvD2JLSMukx7KXY2u0AgtmnzNCDXItRo/+PGH3rC3C27/oyIyykJ94fZsSiz2FffnbEUgmU+x6RzwWfT3KorgG3wI6cECiBmFCZLdBhjoZzPpYyr6LBrIeMbAip3CWxNnayB2zNZIhlrhkPw1WkxcZDBLJaql/P7dQKknU1g94KiPtNjxnO8NSfolFkLGQ3zT0LIoSXYPyHMOiG8xgKczSMgBXkkoCTTSUqWOXlx2QeFdCKBkxxW947fMKpA8nGIhIk4JiycpV1Xf5eQ5alz+Ox3QeUSi22mSN4hhDMyvfLwZeKlpIsQwcQ8zjWuXllHJAdfr3WGLj5LCk6i5NVpYfWtm++SrDiSnGgTlxB7n1SAWcvGvhhm5INta5xgmFOY5i3DwYo9A9NzxZw+7tEZT2k3uY1gmxd6GDJkOhIXAgMBAAEwDQYJKoZIhvcNAQENBQADggIBAI2knmZldxsrJp6Lyk+eLEVbrZI3BuHdfs+9q5I8R2b/RoqEuI05ZxoFPMZGyOMUINsXpthWMGsyALs512nmzR4bD1NGu5Ada3P/UiK3zaZk+xpJ9qAJo9xATRlGkdPhW5HyztUap1M+UW0GA/fDZJLRDVAlF+8czCPahP8ZhP5pkZcPTL/xxvQwDmadmdDRAEObOQlx58SwqQYC/FnO6lEFRhY+Hak9W4E1MoegoG8KFwOvqVRiRx3IVy1vdMQZgRRLDLkZzKIlI8WwkJONObVqdSrF2HfnEk6jhsG7/4Prn16XBSRi7wdqLOnnUpxwKsvL7BZVqAPcJ821XLxZ8wmRVItMnO3qJPP6RqVj7wfB7hnUOLHDywbGGWSrk0gi3x81x3tYXf8S+AbEn59uGIiArZjKmErvgFdtCWS8ILd7EFGYaMSYCCaJxoM/N5LckxAQXmsCgiLeOxXez2+H/uTRbctc5XEgNuVt+k92bF8amaGi5gUO60v7k4hPsnSHFzIqhsfiiOE6Pewyt96teAx4Xc2vMULcc2MUOHeiqK77OzHj8jN+/nztVSnYSrbaPYhJuIXVW5UZExG8kCTSNKK3aS+4++El7sbIHsqBTKvTmQvOMaBrGbZZR5jy5RTZSPi4njBdkjzRogloZRBoOSLebbR4B+4LMeoidxoOQN6O\"\n  ]\n}";

    public string Encrypt(string plain) {
        var jwk = Jwk.FromJson(key, new JsonMapper());
        if (!jwk.KeyOps.Contains("wrapKey"))
            throw new EncryptionException("Key can not be used for encryption");
        return JWE.Encrypt(plain,
            new JweRecipient[] { new(Algorithm, jwk) },
            Encryption,
            compression: Compression,
            mode: SerializationMode,
            extraProtectedHeaders: new Dictionary<string, object> {
                { "kid", jwk.KeyId },
                { "cty", "application/json" }
            }
        );
    }
}
