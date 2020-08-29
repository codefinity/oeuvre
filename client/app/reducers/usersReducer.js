export default (state = [], action) => {
    switch (action.type) {
      case 'AUTHENTICATE':
        return [...state, action.payload];
      default:
        return state;
    }
  };
  