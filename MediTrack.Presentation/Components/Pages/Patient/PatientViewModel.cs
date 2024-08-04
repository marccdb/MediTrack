using MediTrack.Presentation.DTOs;

namespace MediTrack.Presentation.Components.Pages.Patient;

public class PatientViewModel
{

    string connectionString = "https://localhost:7245/api/Patient";
    HttpClient _httpClient = new();



    public async Task<List<PatientDTO>> RetrievePatientList()
    {
        var response = await _httpClient.GetFromJsonAsync<List<PatientDTO>>(connectionString);

        if(response == null)
        {
            throw new Exception("Unable to retrieve list of patients.");
        }

        return response.ToList();
    }



}
