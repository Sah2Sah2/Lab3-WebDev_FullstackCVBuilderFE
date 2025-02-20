using CVBuilderFELogIn.Models;
using CVBuilderFELogIn.Data;

namespace CVBuilderFELogIn.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // ======================= Projects API =======================
        public async Task<List<Project>> GetProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Project>>("api/projects");
        }

        public async Task<Project> GetProjectAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Project>($"api/projects/{id}");
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            var response = await _httpClient.PostAsJsonAsync("api/projects", project);
            return await response.Content.ReadFromJsonAsync<Project>();
        }

        public async Task<Project> UpdateProjectAsync(int id, Project project)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/projects/{id}", project);
            return await response.Content.ReadFromJsonAsync<Project>();
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/projects/{id}");
        }

        // ======================= Skills API =======================
        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Skill>>("api/skills");
        }

        public async Task<Skill> GetSkillAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Skill>($"api/skills/{id}");
        }

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            var response = await _httpClient.PostAsJsonAsync("api/skills", skill);
            return await response.Content.ReadFromJsonAsync<Skill>();
        }

        public async Task<Skill> UpdateSkillAsync(int id, Skill skill)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/skills/{id}", skill);
            return await response.Content.ReadFromJsonAsync<Skill>();
        }

        public async Task DeleteSkillAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/skills/{id}");
        }

        // ======================= Project Skills API =======================
        public async Task AddSkillToProjectAsync(int projectId, int skillId)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/projects/{projectId}/addSkill", skillId);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to add skill to project.");
            }
        }

        public async Task RemoveSkillFromProjectAsync(int projectId, int skillId)
        {
            var response = await _httpClient.DeleteAsync($"api/projects/{projectId}/removeSkill?skillId={skillId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to remove skill from project.");
            }
        }
    }
}
