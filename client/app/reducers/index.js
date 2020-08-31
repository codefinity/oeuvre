import { combineReducers } from 'redux';
import authenticationReducer from './Authentication.reducer';
//import postsReducer from './postsReducer';

export default combineReducers({
    authentication: authenticationReducer
    //,posts: postsReducer

});