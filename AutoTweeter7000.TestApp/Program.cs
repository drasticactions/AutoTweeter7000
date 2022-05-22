// See https://aka.ms/new-console-template for more information
using AutoTweeter7000;
using CoreTweet;

Console.WriteLine("Test Tweet!!");

var consumerToken = TwitterAuthValues.ConsumerKey;

var consumerSecret = TwitterAuthValues.ConsumerSecret;

var client = new CoreTweetClient(consumerToken, consumerSecret);

Console.WriteLine(client.AuthorizeUri);

Console.ReadLine();