var apiKey = '75E5696EB9377FC04B31439534D5DB91'
var apiDomain = 'keenmate.com'

var heroesAPI = 'https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v0001/?key=' + apiKey + '&language=en'

var source   = $("#heroes-template").html();
var template = Handlebars.compile(source);

$.ajax({
	dataType: 'json',
	url: heroesAPI,
}).done(function(data){
	console.log(data.result.heroes);
	var html = template(data.result);

	$("#heroes-list tbody").append(html);
}).fail(function(){
	console.log("Not working!");
});