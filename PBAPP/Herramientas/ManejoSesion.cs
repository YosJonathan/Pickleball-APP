namespace PBAPP.Herramientas
{
    public class ManejoSesion
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManejoSesion(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Agregar<T>(string key, T value)
        {
            _httpContextAccessor?.HttpContext?.Session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));
        }

        public T? Obtener<T>(string key)
        {
            var value = _httpContextAccessor?.HttpContext?.Session.GetString(key);
            return value == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }

        public void Eliminar(string key)
        {
            _httpContextAccessor?.HttpContext?.Session.Remove(key);
        }

        public void Limpiar()
        {
           _httpContextAccessor?.HttpContext?.Session.Clear();
        }
    }
}
