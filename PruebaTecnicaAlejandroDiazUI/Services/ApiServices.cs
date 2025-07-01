using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Blazored.LocalStorage;
using PruebaTecnicaAlejandroDiazUI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PruebaTecnicaAlejandroDiaz.Models;
public class ApiServices
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly IServiceProvider _serviceProvider;

    public ApiServices(HttpClient httpClient, ILocalStorageService localStorage, IServiceProvider serviceProvider)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _serviceProvider = serviceProvider;
    }

    public async Task<ResponseModel<List<EscuelaModels>>> GetListaEscuela()
    {
        var response = await _httpClient.GetAsync($"https://localhost:7289/api/Escuela/GetListaEscuelas");

      

        return await response.Content.ReadFromJsonAsync<ResponseModel<List<EscuelaModels>>>();

    }

    public async Task<ResponseModel<EscuelaModels>> CreateEscuela(string codigo, string nombre, string desc)
    {
        var requestData = new EscuelaModels
        {
            EscuelaId = 0,
            Codigo = codigo,
            Nombre = nombre,
            Descripcion = desc,
            Profesores = [],
            AlumnoEscuelas = []
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Escuela/CreateEscuelas", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<EscuelaModels>>();
    }

    public async Task<ResponseModel<EscuelaModels>> UpdateEscuela(int escuelaId,string codigo, string nombre, string desc)
    {
  
        var requestData = new EscuelaModels
        {
            EscuelaId = escuelaId,
            Codigo = codigo,
            Nombre = nombre,
            Descripcion = desc,
            Profesores = [],
            AlumnoEscuelas = []
        };
        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Escuela/UpdateEscuelas", content);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ResponseModel<EscuelaModels>>();
        }

        throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");

    }

    public async Task<ResponseModel<EscuelaModels>> DeleteEscuela(int escuelaId)
    {
        var requestData = new EscuelaModels
        {
            EscuelaId = escuelaId
          
        };
        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Escuela/DeleteEscuelas?escuelaId={escuelaId}",content);


        return await response.Content.ReadFromJsonAsync<ResponseModel<EscuelaModels>>();
    }




    public async Task<ResponseModel<List<AlumnoModel>>> GetListaAlumnos()
    {
        var response = await _httpClient.GetAsync("https://localhost:7289/api/Alumnos/GetListaAlumnos");

        return await response.Content.ReadFromJsonAsync<ResponseModel<List<AlumnoModel>>>();
    }

    public async Task<ResponseModel<AlumnoModel>> CreateAlumno(string nombre, string apellido, DateTime fechaNacimiento)
    {
        var requestData = new AlumnoModel
        {
            AlumnoId = 0,
            Nombre = nombre,
            Apellido = apellido,
            FechaNacimiento = fechaNacimiento,
            AlumnoEscuelas=[],
            AlumnoProfesores=[]
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7289/api/Alumnos/CreateAlumno", content);

      

        return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoModel>>();
    }

    public async Task<ResponseModel<AlumnoModel>> UpdateAlumno(int alumnoId, string nombre, string apellido, DateTime fechaNacimiento)
    {
        var requestData = new AlumnoModel
        {
            AlumnoId = alumnoId,
            Nombre = nombre,
            Apellido = apellido,
            FechaNacimiento = fechaNacimiento,
            AlumnoEscuelas = [],
            AlumnoProfesores = []
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7289/api/Alumnos/UpdateAlumno", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoModel>>();
    }

    public async Task<ResponseModel<object>> DeleteAlumno(int alumnoId)
    {
        var content = new StringContent("", Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Alumnos/DeleteAlumno?aId={alumnoId}", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<object>>();
    }


    public async Task<ResponseModel<List<ProfesorModel>>> GetListaProfesores()
    {
        var response = await _httpClient.GetAsync($"https://localhost:7289/api/Profesores/GetListaProfesores");
        return await response.Content.ReadFromJsonAsync<ResponseModel<List<ProfesorModel>>>();
    }

   
    public async Task<ResponseModel<ProfesorModel>> CreateProfesor(string nombre, string apellido, int escuelaId)
    {
        var requestData = new ProfesorModel
        {
            ProfesorId = 0,
            Nombre = nombre,
            Apellido = apellido,
            EscuelaId = escuelaId,
            AlumnoProfesores = []
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Profesores/CreateProfesor", content);
        
        return await response.Content.ReadFromJsonAsync<ResponseModel<ProfesorModel>>();
    }


    public async Task<ResponseModel<ProfesorModel>> UpdateProfesor(int profesorId, string nombre, string apellido, int escuelaId)
    {
        var requestData = new ProfesorModel
        {
            ProfesorId = profesorId,
            Nombre = nombre,
            Apellido = apellido,
            EscuelaId = escuelaId,
            AlumnoProfesores = []
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Profesores/UpdateProfesor", content);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<ResponseModel<ProfesorModel>>();

        throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }


    public async Task<ResponseModel<ProfesorModel>> DeleteProfesor(int profesorId)
    {
        var requestData = new ProfesorModel
        {
            ProfesorId = profesorId
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/Profesores/DeleteProfesor?pId={profesorId}", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<ProfesorModel>>();
    }





    public async Task<ResponseModel<List<AlumnoProfesorModel>>> GetListaAlumnosProfesores()
    {
        var response = await _httpClient.GetAsync($"https://localhost:7289/api/AlumnoProfesor/GetListaAlumnosProf\r\n");
        return await response.Content.ReadFromJsonAsync<ResponseModel<List<AlumnoProfesorModel>>>();
    }

    public async Task<ResponseModel<AlumnoProfesorModel>> CreateAlumnoProfesor(AlumnoProfesorModel requestModel)
    {
        var requestData = new AlumnoProfesorModel
        {
            Id = 0,
            AlumnoId = requestModel.AlumnoId,
            ProfesorId = requestModel.ProfesorId
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/AlumnoProfesor/CreateAlumnosProf", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoProfesorModel>>();
    }

    public async Task<ResponseModel<AlumnoProfesorModel>> UpdateAlumnoProfesor(AlumnoProfesorModel requestModel)
    {
        var requestData = new AlumnoProfesorModel
        {
            Id = requestModel.Id,
            AlumnoId = requestModel.AlumnoId,
            ProfesorId = requestModel.ProfesorId
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/AlumnoProfesor/UpdateAlumnosProf", content);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoProfesorModel>>();

        throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }

    public async Task<ResponseModel<AlumnoProfesorModel>> DeleteAlumnoProfesor(int id)
    {
        var requestData = new AlumnoProfesorModel
        {
            Id = id
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/AlumnoProfesor/DeleteAlumnosProf?Id={id}", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoProfesorModel>>();
    }




    public async Task<ResponseModel<List<AlumnoEscuelaModel>>> GetListaAlumnosEscuela()
    {
        var response = await _httpClient.GetAsync($"https://localhost:7289/api/AlumnoEscuela/GetListaAlumnosEsc");
        return await response.Content.ReadFromJsonAsync<ResponseModel<List<AlumnoEscuelaModel>>>();
    }

    public async Task<ResponseModel<AlumnoEscuelaModel>> CreateAlumnoEscuela(AlumnoEscuelaModel requestModel)
    {
        var requestData = new AlumnoEscuelaModel
        {
            Id = 0,
            AlumnoId = requestModel.AlumnoId,
            EscuelaId = requestModel.EscuelaId
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/AlumnoEscuela/CreateAlumnosEsc", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoEscuelaModel>>();
    }

    public async Task<ResponseModel<AlumnoEscuelaModel>> UpdateAlumnoEscuela(AlumnoEscuelaModel requestModel)
    {
        var requestData = new AlumnoEscuelaModel
        {
            Id = requestModel.Id,
            AlumnoId = requestModel.AlumnoId,
            EscuelaId = requestModel.EscuelaId
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/AlumnoEscuela/UpdateAlumnosEsc", content);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoEscuelaModel>>();

        throw new Exception($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }

    public async Task<ResponseModel<AlumnoEscuelaModel>> DeleteAlumnoEscuela(int id)
    {
        var requestData = new AlumnoEscuelaModel
        {
            Id = id
        };

        var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"https://localhost:7289/api/AlumnoEscuela/DeleteAlumnosEsc?Id={id}", content);

        return await response.Content.ReadFromJsonAsync<ResponseModel<AlumnoEscuelaModel>>();
    }






    public class AlumnoProfesorEscuelaDTO
    {
        public int AlumnoId { get; set; }
        public string AlumnoNombre { get; set; }
        public string EscuelaNombre { get; set; }
        public string ProfesorNombre { get; set; }
    }




    public async Task<ResponseModel<List<AlumnoProfesorEscuelaDTO>>> GetAlumnosPorProfesor(int idProf)
    {
        var response = await _httpClient.GetAsync($"https://localhost:7289/api/Vistas/GetListaAlumnosProfesorEscuela?proId={idProf}");
        return await response.Content.ReadFromJsonAsync<ResponseModel<List<AlumnoProfesorEscuelaDTO>>>();
    }
}
