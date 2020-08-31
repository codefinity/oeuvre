import React from 'react';
import { connect } from 'react-redux';
import { hot } from 'react-hot-loader'
import { Router, Route } from 'react-router-dom';
import { history } from '../../helpers';

import AppLayout from './../../layout/default';
import { RoutedContent } from './../../routes';

//const basePath = process.env.BASE_PATH || '/';

// const AppClient = () => {
//     return (
//         <Router basename={ basePath }>
//             <AppLayout>
//                 <RoutedContent />
//             </AppLayout>
//         </Router>
//     );
// }

// export default hot(module)(AppClient);

class App extends React.Component {
    
    // constructor(props) {
    //     super(props);

    //     const { dispatch } = this.props;
    //     history.listen((location, action) => {
    //         // clear alert on location change
    //         dispatch(alertActions.clear());
    //     });
    // }

    render() {
        const { alert } = this.props;
        return (
            <Router history={history}>
                <AppLayout>
                    <RoutedContent />
                </AppLayout>
            </Router>
        );
    }
}

// function mapStateToProps(state) {
//     const { alert } = state;
//     return {
//         alert
//     };
// }

// const connectedApp = connect(mapStateToProps)(App);
// export { connectedApp as App }; 

export default App;