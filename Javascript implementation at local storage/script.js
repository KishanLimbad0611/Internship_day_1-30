const form = document.getElementById('registration-form');
form.addEventListener('submit', function(event) {
  event.preventDefault();
  const name = document.getElementById('name');
  const email = document.getElementById('email');
  const password = document.getElementById('password');
  const confirmPassword = document.getElementById('confirm-password');
  
  
  //////////////////////////for name
  if (name.value.trim() === '') {
    showError(name, 'Name is required');
  } else {
    showSuccess(name);
    localStorage.setItem('Name', name.value);
  }

  ////////////////////////////// for email
  if (email.value.trim() === '') {
    showError(email, 'Email is required');
  } else if (!isValidEmail(email.value.trim())) {
    showError(email, 'Email is not valid');
  } else {
    showSuccess(email);
    localStorage.setItem('Email', email.value);
  }


  //////////////////////////// for Password
  if (password.value.trim() === '') {
    showError(password, 'Password is required');
  } else {
    showSuccess(password);
    localStorage.setItem('Password', password.value);
  }

 ///////////////////////////////for ConfirmPassword
  if (confirmPassword.value.trim() === '') {
    showError(confirmPassword, 'Confirm Password is required');
  } else if (confirmPassword.value.trim() !== password.value.trim()) {
    showError(confirmPassword, 'Passwords do not match');
  } else {
    showSuccess(confirmPassword);
    localStorage.setItem('ConfirmPassword', confirmPassword.value);
  }
});

function showError(input, message) {
  const formField = input.parentElement;    // input.parentElement--->will return the parent element of the input, which could be any HTML element.
  const errorMessage = formField.querySelector('.error-message');   // querySelector---->This function is used to select an HTML element based on a CSS selector.
  input.classList.remove('success');
  input.classList.add('error');
  errorMessage.textContent = message;
}

function showSuccess(input) {
  const formField = input.parentElement;
  const errorMessage = formField.querySelector('.error-message');
  input.classList.add('success');
  input.classList.remove('error');
  errorMessage.textContent = '';
}

function isValidEmail(email) {
  const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;   //^ - Start of the string
                                             // [^\s@]+ - Match one or more characters that are not whitespace or @ symbol
                                             // @ - Match the @ symbol
                                             // [^\s@]+ - Match one or more characters that are not whitespace or @ symbol
                                             // \. - Match a period (escaped with a backslash because dot is a special character in regex)
                                             // [^\s@]+ - Match one or more characters that are not whitespace or @ symbol
                                             //$ - End of the string
  return re.test(email);
}



