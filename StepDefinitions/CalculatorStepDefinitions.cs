using Microsoft.Extensions.Configuration;
using Reqnroll;
using ReqnRollPlayground.Context;
using ReqnRollPlayground.Drivers;
using ReqnRollPlayground.Services;
using System;
using System.Threading;

namespace ReqnRollPlayground.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private CalculatorContext _calculatorContext;
    private MailService _mailService;
    private IConfiguration _configuration;

    public CalculatorStepDefinitions(CalculatorContext calculatorContext, MailService mailService, IConfiguration configuration)
    {
        _calculatorContext = calculatorContext;
        _mailService = mailService;
        _configuration = configuration;
    }

    [Given(@"^Go to url$")]
    public void GoToUrl()
    {
        DriverUtils.GoToUrl(_configuration["Base.Url"]);
    }

    [When(@"^Enter Text Area ""(.*)""$")]
    public void EnterTextArea(string text)
    {
        new PageObject().EnterTextArea(text);

        _calculatorContext.FirstNumber = text;

        Thread.Sleep(new Random().Next(2000, 10000));
    }

    [Then(@"^Print Text$")]
    public void PrintText()
    {

        Console.WriteLine(_calculatorContext.FirstNumber);
    }
}