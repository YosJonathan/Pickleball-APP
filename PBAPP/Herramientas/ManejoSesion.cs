namespace PBAPP.Herramientas
{
    public class ManejoSesion
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ManejoSesion(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Agregar<T>(string key, T value)
        {
            this.httpContextAccessor?.HttpContext?.Session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public T? Obtener<T>(string key)
        {
            var value = this.httpContextAccessor?.HttpContext?.Session.GetString(key);
            return value != null ? System.Text.Json.JsonSerializer.Deserialize<T>(value) : default;
        }

        public void Eliminar(string key)
        {
            this.httpContextAccessor?.HttpContext?.Session.Remove(key);
        }

        public void Limpiar()
        {
           this.httpContextAccessor?.HttpContext?.Session.Clear();
        }
    }
}
