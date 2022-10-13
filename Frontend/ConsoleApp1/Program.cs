using System.Net;

HttpClient client = new HttpClient();
HttpRequestMessage request = new HttpRequestMessage();
request.RequestUri = new Uri("http://localhost:5162/api/books/all");
request.Method = HttpMethod.Get;
request.Headers.Add("Accept", "application/json");

HttpResponseMessage response = await client.SendAsync(request);
if (response.StatusCode == HttpStatusCode.OK)
{
    HttpContent responseContent = response.Content;
    var json = await responseContent.ReadAsStringAsync();
    Console.WriteLine(json);
}
