using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SongsServiceShould
{
    
    // A Test behaves as an ordinary method
    [Test]
    public async void ReturnAnEmptyListOnNotOKStatusCode()
    {
        var messageHandler = new MockHandler(System.Net.HttpStatusCode.BadRequest);
        var mockClient = new HttpClient(messageHandler);
        var service = new SongsService(mockClient);
        var result = await service.GetSongs();
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public async void ReturnAListWithTwoEntities_WhenOKStatusCode()
    {
        var messageHandler = new MockHandler(System.Net.HttpStatusCode.OK);
        messageHandler.AddSuccessResponseString();
        var mockClient = new HttpClient(messageHandler);        
        var service = new SongsService(mockClient);
        var result = await service.GetSongs();
        Assert.AreEqual(2, result.Count);
    }

    
}
