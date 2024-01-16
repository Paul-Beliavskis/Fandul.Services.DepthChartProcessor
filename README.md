# Fandul Depth Chart Processor

This service enables the ability to manage depth charts for various teams and sports

## Running the project

1. First download the codebase
```bash
git clone https://github.com/Paul-Beliavskis/Fandul.Services.DepthChartProcessor.git
```
2. Use Visual Studio to open the solution file found in the src directory
3. Hit f5 and a swagger page will appear with all 4 endpoints
4. Just execute the swagger endpoints to see it in action

## Assumptions

1. I usually aim for more test coverage however I assume you guys just want to see how I write unit tests so I didn't want to go overboard
2. A production quality api was required (could have been a very quick exercise if I did it as a console app)
3. A player with the same number as another player in a certain position cannot be added. You can only add such a player to another position.