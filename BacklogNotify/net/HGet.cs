namespace backlognotify.net
{
    /// <summary>
    /// リクエストを送ります
    /// </summary>
    public class HGet : IDisposable
    {
        HttpClient Client = new HttpClient();

        public void Dispose()
        {
            Client.Dispose();
        }

        public async Task<string> Invoke(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Host", "platform-api.tver.jp");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:98.0) Gecko/20100101 Firefox/98.0");
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Accept-Language", "ja,en-US;q=0.7,en;q=0.3");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Referer", "https:///");
            request.Headers.Add("x-tver-platform-type", "web");
            request.Headers.Add("Origin", "https://");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Sec-Fetch-Dest", "empty");
            request.Headers.Add("Sec-Fetch-Mode", "no-cors");
            request.Headers.Add("Sec-Fetch-Site", "same-site");
            request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("TE", "trailers");

            var response = await Client.SendAsync(request);
            var source = await response.Content.ReadAsStringAsync();
            return source;
        }
    }
}
