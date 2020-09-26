import {authentiationActionTypes} from './Authentication.actiontypes'
import {authenticationServices} from './Authentication.services'
import { history } from '../../helpers';

export const authenticate = (emailId, password) => async dispatch => 
{
  console.log(emailId + " " + password);

  dispatch(request({ emailId }));

  //try {

      //const response = 
      
      authenticationServices.login(emailId, password)
          .then(function (response) {

            console.log("The Response");
            console.log(response);
            dispatch(success(response.data));
            history.push('/');
          
          })
          .catch(function (error) {

            console.log("The Error");
            console.log(error);
            dispatch(failure(error));
          
          });

      //console.log(response.data);

      //dispatch(success(response.data));

      //https://stackoverflow.com/questions/42701129/how-to-push-to-history-in-react-router-v4
      //history.push('/register');

  //}
  //catch(error){
  //    console.log(error);
  //    dispatch(failure(error));
  //}

  function request(emailId) { return { type: authentiationActionTypes.AUTHENTICATE_REQUEST, payload: emailId } }
  function success(data) { return { type: authentiationActionTypes.AUTHENTICATE_SUCCESS, payload: data } }
  function failure(error) { return { type: authentiationActionTypes.AUTHENTICATE_FAILURE, payload: error } }
};

export const register = (tenantId, emailId, firstName, lastName, countryCode, mobileNumber, password, termsAndConditionsAccepted) => async dispatch => 
{

  console.log("Registering");

  dispatch(request({ emailId }));

      authenticationServices.register(tenantId, emailId, firstName, lastName, countryCode, mobileNumber, password, termsAndConditionsAccepted)
          .then(function (response) {

            console.log("The Response");
            console.log(response);
            dispatch(success(response.data));
            //history.push('/');
          
          })
          .catch(function (error) {

            console.log("The Error");
            console.log(error);
            dispatch(failure(error));
          
          });

  function request(emailId) { return { type: authentiationActionTypes.AUTHENTICATE_REQUEST, payload: emailId } }
  function success(data) { return { type: authentiationActionTypes.AUTHENTICATE_SUCCESS, payload: data } }
  function failure(error) { return { type: authentiationActionTypes.AUTHENTICATE_FAILURE, payload: error } }

};

export const signOut = () => async dispatch => {

  authenticationServices.signOut();
  dispatch(request());

  history.push('/');

  function request() { return { type: authentiationActionTypes.SIGNOUT } }
}

// export const fetchUser = id => async dispatch => {
//   const response = await jsonPlaceholder.get(`/users/${id}`);

//   dispatch({ type: 'FETCH_USER', payload: response.data });
// };
