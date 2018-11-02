using Shouldly;
using System.Net.Mail;
using Xunit;

namespace CanonicalEmails.Tests
{
    public class NormalizerTests
    {
        [Fact]
        public void Should_retain_original_display_name()
        {
            var expected = new MailAddress("user@example.com", "Example User");
            Normalizer.Normalize(expected).DisplayName.ShouldBe(expected.DisplayName);
        }

        [Theory]
        [InlineData("userexample@gmail.com")]
        [InlineData("user.example@gmail.com")]
        [InlineData("user.example+mytag@gmail.com")]
        [InlineData("userexample+mytag@gmail.com")]
        [InlineData("userexample@googlemail.com")]
        public void Gmail_should_normalize_to(string email)
        {
            var normalized = Normalizer.Normalize(new MailAddress(email));
            normalized.ShouldBe(new MailAddress("userexample@gmail.com"));
        }

        [Theory]
        [InlineData("userexample@hotmail.com", "userexample@hotmail.com")]
        [InlineData("user.example@hotmail.com", "user.example@hotmail.com")]
        [InlineData("user.example+mytag@hotmail.com", "user.example@hotmail.com")]
        [InlineData("userexample+mytag@hotmail.com", "userexample@hotmail.com")]
        public void Hotmail_should_normalize_to(string email, string expected)
        {
            var normalized = Normalizer.Normalize(new MailAddress(email));
            normalized.ShouldBe(new MailAddress(expected));
        }

        [Theory]
        [InlineData("userexample+mytag@pm.me")]
        [InlineData("userexample+sometag@protonmail.com")]
        public void Protonmail_should_normalize_to(string email)
        {
            var normalized = Normalizer.Normalize(new MailAddress(email));
            normalized.ShouldBe(new MailAddress("userexample@protonmail.com"));
        }

        [Fact]
        public void Should_not_lowercase()
        {
            var settings = new NormalizerSettings { LowerCase = false };
            var expected = new MailAddress("uSeR@example.com");
            Normalizer.Normalize(expected, settings).ShouldBe(expected);
        }

        [Fact]
        public void Should_not_remove_dots()
        {
            var settings = new NormalizerSettings { RemoveDots = false };
            var expected = new MailAddress("user.example@gmail.com");
            Normalizer.Normalize(expected, settings).ShouldBe(expected);
        }

        [Fact]
        public void Should_not_remove_tags()
        {
            var settings = new NormalizerSettings { RemoveTags = false };
            var expected = new MailAddress("user.example+foo@gmail.com");
            Normalizer.Normalize(expected, settings).ShouldBe(new MailAddress("userexample+foo@gmail.com"));
        }

        [Fact]
        public void Should_not_replace_host()
        {
            var settings = new NormalizerSettings { NormalizeHost = false };
            var expected = new MailAddress("user@googlemail.com");
            Normalizer.Normalize(expected, settings).ShouldBe(expected);
        }
    }
}
