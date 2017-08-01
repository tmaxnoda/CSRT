(function(){

  var now = new Date();
  var hours = now.getHours();
  var bodyClass = '';
  var $greeting = document.getElementById('js_greeting');
  var $body = document.getElementsByTagName("BODY")[0];
  var greetingString = 'Hello!';

  console.log(hours);

  if (hours > 20 || hours < 4) {
    bodyClass = 'night';
    greetingString = 'Good night!';
  } else if (hours > 16) {
    bodyClass = 'evening';
    greetingString = 'Good evening!';
  } else if (hours > 11) {
    bodyClass = 'noon';
    greetingString = 'Good afternoon!';
  } else if (hours > 3 ) {
    bodyClass = 'morning';
    greetingString = 'Good morning!';
  }

  if ($greeting !== null) $greeting.textContent = greetingString;
  if ($body !== null) $body.classList.add(bodyClass);

}());
