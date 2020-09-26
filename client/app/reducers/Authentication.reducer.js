import {authentiationActionTypes} from '../routes/Authentication/Authentication.actiontypes'

const initialState = {LoggingIn : false,
                      LoggedIn: false,
                      Registering: false,
                      RegistationSuccess: false,
                      RegistatiFail: false}; //user ? { loggedIn: true } : {};

export default (state = initialState, action) => {
              
  switch (action.type) {
    
    //Authentication
    case authentiationActionTypes.AUTHENTICATE_REQUEST:

      return {...state, LoggingIn : true };

    case authentiationActionTypes.AUTHENTICATE_SUCCESS:

        return {...state, LoggedIn : true };

    case authentiationActionTypes.AUTHENTICATE_FAILURE:

        return {...state, LoggedIn : false };

    //Registration
    case authentiationActionTypes.REGISTER_REQUEST:

      return {...state, Registering : true };

    case authentiationActionTypes.REGISTER_SUCCESS:

        return {...state, RegistationSuccess : true };

    case authentiationActionTypes.REGISTER_FAILURE:

        return {...state, RegistatiFail : true };

    //Signot
    case authentiationActionTypes.SIGNOUT:

      return {...state, LoggedIn : false };

    default:
                  
      return state;
              
    }
  };
  