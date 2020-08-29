export const authenticate = () => async dispatch => {

  //Make an Axios Request
  //const response = await jsonPlaceholder.get('/posts');

  dispatch({ 
    type: 'AUTHENTICATE', 
    payload: response.data });

};

// export const fetchUser = id => async dispatch => {
//   const response = await jsonPlaceholder.get(`/users/${id}`);

//   dispatch({ type: 'FETCH_USER', payload: response.data });
// };
