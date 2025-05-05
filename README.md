IMPORTANT: Getting this project to work may require running update-database in the package manager console. If that doesn't work, try generating a new migration and try it again.

AI disclosure:
While I originally planned on not using AI at all, as I do not support the use of generative AI, after not making any progress at all for weeks and countless hours working on the project up until the due date 
was getting close, it began to feel as if I needed to use AI to get the project in a workable state by the deadline and I was actively putting myself at a disadvantage in not doing so. So, I used AI to moslty 
explain concepts to me and assist in debugging. I only used AI to generate code for me directly on two occasions. Those will be listed below:

AI generated code #1:
var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


AI generated code #2:
DateOnly releaseDate = DateOnly.ParseExact(gameVM.ReleaseDate, "yyyy-MM-dd", CultureInfo.CurrentCulture);


All other code is by my own creation, either through general knowlege or extensive research through ASP.NET documentation.

In hindsight, I should have leaned more on AI, as I am not happy with the "final" product of this project in any capacity. However, I was too stubborn and overestimated the time it would take for me not to.


