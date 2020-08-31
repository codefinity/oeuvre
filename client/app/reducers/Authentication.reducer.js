import {authentiationActionTypes} from '../routes/Authentication/Authentication.actiontypes'

const initialState = {LoggingIn : false,
                      LoggedIn: false }; //user ? { loggedIn: true } : {};

export default (state = initialState, action) => {
              
  switch (action.type) {
                
    case authentiationActionTypes.AUTHENTICATE_REQUEST:

      return {...state, LoggingIn : true };

    case authentiationActionTypes.AUTHENTICATE_SUCCESS:

        return {...state, LoggedIn : true };

    case authentiationActionTypes.AUTHENTICATE_FAILURE:

        return {...state, LoggedIn : false };

    case authentiationActionTypes.SIGNOUT:

      return {...state, LoggedIn : false };

    default:
                  
      return state;
              
    }
  };
  