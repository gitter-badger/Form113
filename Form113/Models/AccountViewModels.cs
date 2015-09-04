using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Form113.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Mémoriser ce navigateur ?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Courrier électronique")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Display(Name = "Mémoriser le mot de passe ?")]
        public bool RememberMe { get; set; }
    }
    /// <summary>
    /// Modifié pour ajouter des données autres que email/mot de passe pour un utilisateur.
    /// 
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [System.Web.Mvc.Remote("CheckEmail", "Json", ErrorMessage = "l'email est déjà utilisé")]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// pour stocker les données regions/departements à fournir aux listes déroulantes
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> RegionsDepartements { get; set; }


        /// <summary>
        /// code insee de la ville
        /// </summary>
        public string CodeVille { get; set; }
        [DisplayName("numero de voie :")]
        public string Adresse1 { get; set; }

        [DisplayName("Voie :")]
        public string Adresse2 { get; set; }

        [DisplayName("Complément d'adresse :")]
        public string Adresse3 { get; set; }

        [DisplayName("Nom :")]
        public string Nom { get; set; }

        [DisplayName("Prenom :")]
        public string Prenom { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }

    public class EditViewModel
    {
        [Required]
        [EmailAddress]
        [System.Web.Mvc.Remote("CheckEmail", "Json", ErrorMessage = "l'email est déjà utilisé")]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// pour stocker les données regions/departements à fournir aux listes déroulantes
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> RegionsDepartements { get; set; }


        /// <summary>
        /// Pour afficher le département enregistré lors du formulaire d'édition de compte
        /// </summary>
        public string iddep { get; set; }


        /// <summary>
        /// code insee de la ville
        /// </summary>
        public string CodeVille { get; set; }
        [DisplayName("numero de voie :")]
        public string Adresse1 { get; set; }

        [DisplayName("Voie :")]
        public string Adresse2 { get; set; }

        [DisplayName("Complément d'adresse :")]
        public string Adresse3 { get; set; }

        [DisplayName("Nom :")]
        public string Nom { get; set; }

        [DisplayName("Prenom :")]
        public string Prenom { get; set; }
    }
}
