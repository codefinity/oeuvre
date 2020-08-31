import axios from "axios";
import qs from 'qs';

export const authenticationServices = {
    login,
    logout
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

function logout() {
    // remove token from local storage to log user out
    localStorage.removeItem('token');
}