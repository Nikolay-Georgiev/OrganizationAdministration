using System.ComponentModel.DataAnnotations;

namespace OrganizationAdministration.Data
{
    public enum ExperienceLevel
    {
        Newcomer,
        Standard,
        Experienced,
        [Display(Name = "Very Experienced")]
        VeryExperienced
    }
}
