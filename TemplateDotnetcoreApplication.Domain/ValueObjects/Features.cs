using System.ComponentModel;

namespace TemplateDotnetcoreApplication.Domain.ValueObjects
{
    public enum Features
    {
        [Description("GetGitIgnoreFeature")]
        GetGitIgnoreFeature,
        [Description("GitIgnoreFeature")]
        GitIgnoreFeature
    }
}
