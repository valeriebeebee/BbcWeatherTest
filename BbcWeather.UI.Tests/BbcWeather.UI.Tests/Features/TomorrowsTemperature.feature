Feature: TomorrowsTemperature
A simple calculator to test Specflow
            
    Scenario: high temperature is higher than low temperature is low
        Given I have openedd a new driver window
        When I am on the BBC Weather page
        When I search for 'Bournemouth'
        Then tomorrow's high temperature is higher than tomorrow's low temperature