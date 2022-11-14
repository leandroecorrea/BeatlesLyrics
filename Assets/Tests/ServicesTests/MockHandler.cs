using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class MockHandler : HttpMessageHandler
{
    private readonly HttpStatusCode _statusCode;
    private HttpResponseMessage _result;

    public MockHandler(HttpStatusCode statusCode)
    {
        _statusCode = statusCode;
        _result = new HttpResponseMessage(_statusCode);
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_result);
    }

    public void AddSuccessResponseString()
    {
       var jsonString = @"[{""_id"":""5eb4c5e400622e0004adf826"",""Name"":""George Harrison"",""Song"":""Any Road"",""Lyrics"":""Oh I've been traveling on a boat and a plane   /  In a car on a bike with a bus and a train   /  Traveling there and traveling here   /  Everywhere in every gear   /    But oh Lord we pay the price with a   /  Spin of a wheel with the roll of a dice   /  Ah yeah you pay your fare   /  And if you don't know where you're going   /  Any road will take you there   /    And I've been traveling through the dirt and the grime   /  From the past to the future through the space and the time   /  Traveling deep beneath the waves   /  In wattery grottoes and mountainous caves   /    But oh Lord we've got to fight   /  With the thoughts in the head with the dark and the light   /  No use to stop and stare   /  And if you don't know where you're going   /  Any road will take you there   /    You may not know where you came from   /  May not know who you are   /  May not even wondered how   /  You got this far   /    I've been traveling on a wing and a prayer   /  By the skin of my teeth by the breadth of a hair   /  Traveling where the four winds blow   /  With the sun on my face, in the ice and the snow   /    But ooee it's a game   /  Sometimes you're cool, sometimes you're lame   /  Ah yea it's somewhere   /  And if you don't know where you're going   /  Any road will take you there   /    But oh Lord we pay the price   /  With the spin of a wheel, with the roll of a dice   /  Ah yea, you pay your fare   /  And if you don't know where you're going   /  Any road will take you there   /    I keep traveling around the bend   /  There was no beginning, there is no end   /  It wasn't born and never dies   /  There are no edges, there is no sides   /  Oh yea, you just don't win   /  It's so far out - the way out is in   /  Bow to God and call him Sir   /    But if you don't know where you're going   /  Any road will take you there"",""__v"":0},{""_id"":""5eb4c5e400622e0004adf827"",""Name"":""George Harrison"",""Song"":""Can't Stop Thinking About You"",""Lyrics"":""Can't stop thinking about you   /  Can't stop thinking about you   /  Its no good living without you   /  I can't stop thinking about you   /    Can't stop thinking about you   /  Can't stop thinking about you   /  And it's no good living without you   /  I can't stop thinking about you   /    When the night-time comes around   /  Daylight has left me, I   /  I can't take it if I don't see you no more   /  I can't help it, I need your loving so much more   /    And I can't stop thinking about you   /  Can't stop thinking about you   /  And it's no good living without you   /  I can't stop thinking about   /  I can't stop thinking about   /  I can't stop thinking about you, ooh   /    Can't stop thinking about   /  Can't stop thinking about   /  Can't stop thinking about you   /    When the morning comes around   /  And the daylight gets to me, I   /  I can't take it if I don't see you no more   /  I can't help it, I need your loving so much more   /    And I can't stop thinking about you, oh yeah   /  I can't stop thinking about you   /  And it's no good living without you   /  I can't stop thinking about   /  I can't stop thinking about   /  I can't stop thinking about you   /    I can't stop thinking about   /  Can't stop thinking about   /  Can't stop thinking about you   /    (repeat and fade:)   /  I can't stop thinking about   /  I can't stop thinking about   /  I can't stop thinking about you"",""__v"":0}]";
        _result.Content = new StringContent(jsonString);
    }

    
}