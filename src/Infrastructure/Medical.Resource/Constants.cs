namespace Medical.Resource
{
    public static class Constants
    {
        #region System

        public static string LANGUAGE_SPANISH_PERU = "es-PE";

        public static string SYSTEM_PREFIX_NAME = "Sistema";
        public static string SYSTEM_LEAD = "Sistema de Gestión Médica";
        public static string SYSTEM_AUTHOR_NAME = "Medical Systems Services";

        public static string ADMIN_GUID => "8e445865-a24d-4543-a6c6-9443d048cdb9";
        public static string ADMIN_EMAIL => "admin@thaniwasi.com";
        public static string ADMIN_PASSWORD => "Thaniwasi.123";
        public static string ADMIN_NAME => "Administrador";
        public static string ADMIN_ROLE_NAME => "Administrador";
        public static string ADMIN_ROLE_GUID => "cbc43a8e-f7bb-4445-baaf-1add431ffbbf";

        public static string USER_NAME => "Usuario";
        public static string USER_ROLE_NAME => "Usuario";
        public static string USER_ROLE_GUID => "cac43a6e-f7bb-4448-baaf-1add431ccbbf";
        public static string USER_THUMBNAIL_PATH => "images/user.png";
        public static string USER_THUMBNAIL_CIRCLE_PATH => "images/user-circle.png";

        #endregion

        #region Application

        public static string APPLICATION_NAME = "Thaniwasi";
        public static string APPLICATION_LEAD = "Integrativo y Natural";

        #region Login

        public static string LOGIN_FORM_TITLE = "Iniciar Sesión";
        public static string LOGIN_FORM_USERNAME = "Usuario";
        public static string LOGIN_FORM_SIGNOUT = "Cerrar Sesión";
        public static string LOGIN_FORM_EMAIL_PLACEHOLDER = "Por favor ingrese su correo electrónico";
        public static string LOGIN_FORM_PASSWORD_PLACEHOLDER = "Por favor ingrese su correo contraseña";
        public static string LOGIN_FORM_SUBMIT = "Ingresar";
        public static string LOGIN_FORM_FORGOT_PASSWORD = "Olvidé mi contraseña";
        public static string LOGIN_FORM_REGISTER = "Registrarse";

        #endregion


        public static string PROFILE_TITLE = "Perfil";

        public static string SETTINGS_TITLE = "Configuración";

        public static string NOTIFICATIONS_TITLE = "Notificaciones";

        public static string NOTIFICATIONS_UNREAD = "Usted tiene {0} notificaciones sin leer";

        public static string NOTIFICATIONS_VIEW_ALL = "Ver todas las notificaciones";

        #endregion

        #region Patients

        public static string PATIENTS_MODULE_NAME = "Pacientes";

        #endregion

        #region Colors

        public static string COLOR_PRIMARY = "#217439";
        public static string COLOR_PRIMARY_LIGHT = "#87B93B";
        public static string COLOR_SECONDARY = "#6A4D2B";
        public static string COLOR_SECONDARY_LIGHT = "#AA9D8E";
        public static string COLOR_ACCENT = "#DF0F82";

        #endregion
    }
}
