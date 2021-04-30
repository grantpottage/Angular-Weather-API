# Angular-Weather-API

Firstly, thank you for taking the time to consider me as an applicant. Just want to let you know a bit about what I did and why.

I used Angular as the front end. This is actually a first for me. I've only used AngularJS in the past which isn't exactly similar but they do of course have their similarities. I really enjoyed making this project and learning a new skill. I will definitely be using angular for more in the future after this experience.

With regards to my ApiService, usually I would have a separate class for the api itself which will take in a type so it can deserialize the object into that type then return it. And then the ApiService would contain the business logic. However, due to only having one endpoint and 2 urls I thought it would be easier and more convenient to keep it simpler as my usual method would over complicate this task.

I used the default authorization that comes with angular on Visual Studio. Emails are not set up so I have disabled the "RequireConfirmedAccount" option in the startup file.

I used the following angular component for the pull to refresh:
https://github.com/YeongCheon/ngx-pull-to-refresh#readme

I added the option to search for other cities as well (Just for fun and to learn a bit more of Angular).

I created a small test project that uses XUnit and Mocking. It just has 2 very basic tests in it. In most scenarios I would be mocking and testing all the dependencies used but the only dependencies getting used are ones provided by .Net which wouldn't need testing (E.G HttpClient).

Once again thank you for your time and I look forward to any feedback.
