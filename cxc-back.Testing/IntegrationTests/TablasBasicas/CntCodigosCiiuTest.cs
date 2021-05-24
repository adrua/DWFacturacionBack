// CntCodigosCiiu - APIRest - OData Testing
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Xunit;

using Cxc.TablasBasicas.Models;
using Cxc_Backend;
using Cxc_Backend.Testing;

namespace Cxc.TablasBasicas.Tests.IntegrationTests
{
    public class CntCodigosCiiuTest
    : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        #region Tests
        [Theory]
        [InlineData("/odata/v1/CntCodigosCiiu(CodigoCiiuId='.02234')")]
        public async Task GetById_NotImplemented(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            
            // Act
            var response = await client.GetAsync($"{Utilities.BaseAddress}{url}");

            // Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            Assert.Equal("Method Not Allowed", response.ReasonPhrase);
            Assert.True(response.Content.Headers.ContentType == null);
        }

        [Theory]
        [InlineData("/odata/v1/CntCodigosCiiu")]
        public async Task Get(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var response = await client.GetAsync($"{Utilities.BaseAddress}{url}");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.Equal("application/json; odata.metadata=minimal; odata.streaming=true", response.Content.Headers.ContentType.ToString());
            dynamic json = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            Assert.True(json.value.Count >= 1);
        }

        [Theory]
        [InlineData("/odata/v1/CntCodigosCiiu")]
        public async Task Get_Unauthorized(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{Utilities.BaseAddress}{url}");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("Unauthorized", response.ReasonPhrase);

            Assert.Null(response.Content.Headers.ContentType);
            Assert.Equal("", response.Content.ReadAsStringAsync().Result);
        }

        [Theory]
        [InlineData("/odata/v1/CntCodigosCiiu")]
        public async Task Post_OK(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var contentJson = JsonConvert.SerializeObject(rowAdd, Formatting.None, Utilities.JsonSerializerSettings);
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");
            var response = await client.PostAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            Assert.Equal("application/json; odata.metadata=minimal; odata.streaming=true", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/odata/v1/CntCodigosCiiu")]
        public async Task Post_Duplicate(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var contentJson = JsonConvert.SerializeObject(rowBase, Formatting.None, Utilities.JsonSerializerSettings);
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");
            var response = await client.PostAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Bad Request", response.ReasonPhrase);

            Assert.Equal("application/json; odata.metadata=minimal; odata.streaming=true", response.Content.Headers.ContentType.ToString());
            dynamic json = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            Assert.StartsWith("Llave primaria duplicada (", json.value.ToString());
        }

        [Theory]
        [InlineData("/odata/v1/CntCodigosCiiu")]
        public async Task Post_Unauthorized(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var contentJson = JsonConvert.SerializeObject(rowAdd, Formatting.None, Utilities.JsonSerializerSettings);
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("Unauthorized", response.ReasonPhrase);

            Assert.Null(response.Content.Headers.ContentType);
            Assert.Equal("", response.Content.ReadAsStringAsync().Result);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='.02234')")]
        public async Task Patch_OK(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var contentJson = JsonConvert.SerializeObject(rowBase, Formatting.None, Utilities.JsonSerializerSettings);
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");
            var response = await client.PatchAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.Equal("No Content", response.ReasonPhrase);

            Assert.True(response.Content.Headers.ContentType == null);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='.')")]
        public async Task Patch_NotFound(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var contentJson = JsonConvert.SerializeObject(rowBase, Formatting.None, Utilities.JsonSerializerSettings);
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");
            var response = await client.PatchAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Bad Request", response.ReasonPhrase);

            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType.ToString());
            var msg = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("Error actualizando, Fila no existe.", msg);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='.02234')")]
        public async Task Patch_Unauthorized(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var contentJson = JsonConvert.SerializeObject(rowBase, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter>() { new Newtonsoft.Json.Converters.StringEnumConverter() }
            });
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");
            var response = await client.PatchAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("Unauthorized", response.ReasonPhrase);

            Assert.Null(response.Content.Headers.ContentType);
            Assert.Equal("", response.Content.ReadAsStringAsync().Result);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='.02234')")]
        public async Task Put_NotImplemented(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var contentJson = JsonConvert.SerializeObject(rowBase, Formatting.None, Utilities.JsonSerializerSettings);
            var content = new StringContent(contentJson, ASCIIEncoding.UTF8, "application/json");
            var response = await client.PutAsync($"{Utilities.BaseAddress}{url}", content);

            // Assert
            Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            Assert.Equal("Method Not Allowed", response.ReasonPhrase);

            Assert.True(response.Content.Headers.ContentType == null);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='002234')")]
        public async Task Delete_OK(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var response = await client.DeleteAsync($"{Utilities.BaseAddress}{url}");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.True(response.Content.Headers.ContentType == null);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='.')")]
        public async Task Delete_NotFound(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var response = await client.DeleteAsync($"{Utilities.BaseAddress}{url}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("Bad Request", response.ReasonPhrase);

            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType.ToString());
            var msg = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("Error eliminando, Fila no existe.", msg);
        }

        [Theory]
        [InlineData("/CntCodigosCiiu(CodigoCiiuId='002234')")]
        public async Task Delete_Unauthorized(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"{Utilities.BaseAddress}{url}");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("Unauthorized", response.ReasonPhrase);

            Assert.Null(response.Content.Headers.ContentType);
            Assert.Equal("", response.Content.ReadAsStringAsync().Result);
        }
        #endregion

        #region Setup
        Utilities Utilities = null;
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private string _token;

        private static CntCodigosCiiu rowBase = new CntCodigosCiiu() {
            CodigoCiiuId = $@".02234",
            CodigoCiiuDescripcion = $@"Fabricación de artículos de viaje bolsos de mano y artículos similares elaborados en cuero y fabricación de artículos de talabartería ",
            CodigoCiiuclase = true,
            CodigoCiiugrupo = false,
            CodigoCiiudivision = false,
            CodigoCiiuBloqueo = false,
        };

        private static CntCodigosCiiu rowAdd = new CntCodigosCiiu() {
            CodigoCiiuId = $@"/02234",
            CodigoCiiuDescripcion = $@"Gabricación de artículos de viaje bolsos de mano y artículos similares elaborados en cuero y fabricación de artículos de talabartería ",
            CodigoCiiuclase = true,
            CodigoCiiugrupo = false,
            CodigoCiiudivision = false,
            CodigoCiiuBloqueo = false,
        };

        private static CntCodigosCiiu rowDelete = new CntCodigosCiiu() {
            CodigoCiiuId = $@"002234",
            CodigoCiiuDescripcion = $@"Habricación de artículos de viaje bolsos de mano y artículos similares elaborados en cuero y fabricación de artículos de talabartería ",
            CodigoCiiuclase = true,
            CodigoCiiugrupo = false,
            CodigoCiiudivision = false,
            CodigoCiiuBloqueo = false,
        };

        public CntCodigosCiiuTest(CustomWebApplicationFactory<Startup> factory)
        {

            _factory = factory;

            if (factory.Db == null)
            {
                _factory.InitializeDbForTests = (db) =>
                {
                    if (db.CntCodigosCiiu.Count() == 0)
                    {
                        db.CntCodigosCiiu.Add(rowBase);
                        db.CntCodigosCiiu.Add(rowDelete);
                        db.SaveChanges();
                    }

                    Utilities = _factory.utilities;
                    _token = _factory.Token;
                };
            }
            else
            {
                Utilities = _factory.utilities;
                _token = _factory.Token;
            }
        }
        #endregion
    }
}