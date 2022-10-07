using IdentityServer.Domain.DTO_s.User;

namespace IdentityServer.Domain.Constants.ErrorMessages
{
    public static class UserErrorMessages
    {
        public static string UserNotAuthenticated = "E-mail ou senha incorretos";
        public static string UserNotFound = "Usuário não encontrado";
        public static string UserEmailAlreadyExist = "E-mail já cadastrado";
        public static string UserEmailInvalid = "E-mail inválido";
        public static string UserNotCreated = "Não foi possível criar o usuário";


        public static string GetUserResultErrors(IEnumerable<UserResultErrorDTO> errors) =>
            GenerateUserResultErrorsMessage(errors.Select(error => error.Code));
       
        private static string GenerateUserResultErrorsMessage(IEnumerable<string> codErrors)
        {
            const string SEPARATOR = ". ";
            return string.Join(SEPARATOR, UserResultErrors
                                               .Where(error => codErrors.Contains(error.Key))
                                               .Select(error => error.Value));
        }

        private static Dictionary<string, string> UserResultErrors => new Dictionary<string, string>()
        {
            { "PasswordRequiresUpper", "A senha deve possuir ao menos 1 letra maiúscula" },
            { "PasswordTooShort", "A senha deve possuir uma quantidade maior de caracteres" },
            { "DuplicateUserName", "Usuário já cadastrado" },
            { "InvalidUserName", "Nome do usuário é somente permitido letras e números" }
        };
    }
}
