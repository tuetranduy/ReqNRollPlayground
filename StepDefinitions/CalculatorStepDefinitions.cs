using System;
using Reqnroll;
using ReqnRollPlayground.Context;
using ReqnRollPlayground.Services;

namespace ReqnRollPlayground.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private CalculatorContext _calculatorContext;
    private MailService _mailService;
    
    public CalculatorStepDefinitions(CalculatorContext calculatorContext, MailService mailService)
    {
        _calculatorContext = calculatorContext;
        _mailService = mailService;
    }
    
    [Given(@"^the first number is (.*)$")]
    public void GivenTheFirstNumberIs(int number)
    {
        _calculatorContext.FirstNumber = number;
    }

    [Given(@"^the second number is (.*)$")]
    public void GivenTheSecondNumberIs(int number)
    {
        _calculatorContext.SecondNumber = number;
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _calculatorContext.Result = _calculatorContext.FirstNumber + _calculatorContext.SecondNumber;
    }

    [Then(@"^the result should be (.*)$")]
    public void ThenTheResultShouldBe(int result)
    {
        Console.WriteLine(_calculatorContext.Result);
    }
    
    [When("Send email")]
    public void SendEmail()
    {
        _mailService.SendMail("test", "test");
    }

}