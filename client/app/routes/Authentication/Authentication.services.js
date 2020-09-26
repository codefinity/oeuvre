import axios from "axios";
import qs from 'qs';

export const authenticationServices = {
    login,
    signOut,
    register
}


async function login(emailId, password) {

    const data = qs.stringify({
        grant_type: 'password',
        username: emailId,
        password: password,
        client_id: 'ro.client',
        client_secret: 'secret'
      });
    
      const headers = {
        'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8'
      };
    
      const response = await axios.post(
        'http://localhost:5002/connect/token', 
        data, 
        headers
      )

      console.log("Token: " + response.data.access_token);

      localStorage.setItem('token', response.data.access_token);

      return response;
}

async function register(tenantId, emailId, firstName, lastName, countryCode, mobileNumber, password, termsAndConditionsAccepted) {

  const data = {
      tenantId: tenantId,
      emailId: emailId,
      firstName: firstName,
      lastName: lastName,
      countryCode: countryCode,
      mobileNumber: mobileNumber,
      password: password,
      termsAndConditionsAccepted: termsAndConditionsAccepted
    };
  
    const headers = {
      'Content-Type': 'application/json'
    };
  
    const response = await axios.post(
      'http://localhost:5000/identityaccess/register',
      data,
      headers
    )

    return response;
}

async function signOut() {
    // remove token from local storage to log user out
    localStorage.removeItem('token');
}