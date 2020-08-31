    import React from 'react';
    import { Link } from 'react-router-dom';
    import { connect } from 'react-redux';
    import {
        //Button,
        DropdownToggle,
        Nav,
        NavItem,
        NavLink,
        Avatar,
        AvatarAddOn,
        Navbar,
        NavbarToggler,
        UncontrolledDropdown,
        DropdownMenu, 
        DropdownItem
        //,ThemeConsumer,
    } from '../../components';
    import { randomAvatar } from './../../utilities';
    import { NavbarActivityFeed } from './NavbarActivityFeed';
    //import { NavbarMessages } from './../../../layout/components/NavbarMessages';
    //import { NavbarUser } from './../../../layout/components/NavbarUser';
    import { DropdownProfile } from './../../routes/components/Dropdowns/DropdownProfile';
    //import { NavbarNavigation } from './../../components/Navbars/NavbarNavigation';
    import { LogoThemed } from '../../routes/components/LogoThemed/LogoThemed';
    import { signOut } from '../../routes/Authentication/Authentication.actions';

    class DefaultNavbar extends React.Component {

        signOut =(e) => {

            console.log("Logout Clicked");
            this.props.signOut();
        }

        render() {

            console.log("LoggingIn in Navbar:" + this.props.authentication.LoggedIn);

            return(
                <React.Fragment>
                    <Navbar light expand="lg" themed>
                        <Link to="/" className="navbar-brand mr-0 mr-sm-3">
                            <LogoThemed className="mb-1" checkBackground />
                        </Link>

                        <Nav pills>
                            <NavItem>
                                <NavLink tag={ NavbarToggler } id="navbar-navigation-toggler" className="b-0">
                                    <i className="fa fa-fw fa-bars"></i>
                                </NavLink>
                            </NavItem>
                        </Nav>

                        { /* Navigation with Collapse */ }
                        {/* <NavbarNavigation pills /> */}

                        { /* END Navbar: Left Side */ }
                        { /* START Navbar: Right Side */ }

                        {this.props.authentication.LoggedIn
                            ?<Nav className="ml-auto" pills>
                            {/* <NavbarMessages /> */}
                            <NavbarActivityFeed />
                            { /* START Navbar: Dropdown */ }
                            <UncontrolledDropdown nav inNavbar>
                                <DropdownToggle nav>
                                    <Avatar.Image
                                        size="sm"
                                        src={ randomAvatar() }
                                        addOns={[
                                            <AvatarAddOn.Icon 
                                                className="fa fa-circle"
                                                color="white"
                                                key="avatar-icon-bg"
                                            />,
                                            <AvatarAddOn.Icon 
                                                className="fa fa-circle"
                                                color="danger"
                                                key="avatar-icon-fg"
                                            />
                                        ]}
                                    /> 
                                </DropdownToggle>
                                {/* <DropdownProfile  right /> */}
                                <React.Fragment>
                                    <DropdownMenu right={true} >
                                        <DropdownItem header>
                                            { "FName" } { "LName" }
                                        </DropdownItem>
                                        <DropdownItem divider />
                                        <DropdownItem tag={ Link } to="/apps/profile-details">
                                            My Profile
                                        </DropdownItem>
                                        <DropdownItem tag={ Link } to="/apps/settings-edit">
                                            Settings
                                        </DropdownItem>
                                        <DropdownItem tag={ Link } to="/apps/billing-edit">
                                            Billings
                                        </DropdownItem>
                                        <DropdownItem divider />
                                        <DropdownItem  onClick={this.signOut} >
                                            <i className="fa fa-fw fa-sign-out mr-2"></i>
                                            Sign Out
                                        </DropdownItem>
                                    </DropdownMenu>
                                </React.Fragment>
                            </UncontrolledDropdown>
                            { /* END Navbar: Dropdown */ }
                            {/* <NavbarUser className="d-none d-lg-block" /> */}
                        </Nav>
                        :<Nav pills>
                            <Link to="/login" className="text-dark">
                            <strong>Sign In</strong>
                            </Link>
                        </Nav>
                        }

                        { /* END Navbar: Right Side */ }
                    </Navbar>

                    {/* <Navbar light shadow expand="lg" className="py-3 bg-white">
                        <h1 className="mb-0 h4">
                            Navbar Only
                        </h1>
                        
                        <ThemeConsumer>
                        {
                            ({ color }) => (
                                <Button color={ color } className="px-4 my-sm-0">
                                    Download <i className="fa ml-1 fa-fw fa-download"></i>
                                </Button>
                            )
                        }
                        </ThemeConsumer>
                    </Navbar> */}
                </React.Fragment>
            );
        }
    }

    const mapStateToProps = state => {
        return { authentication: state.authentication };
    };
    
    export default connect(
        mapStateToProps,
        { signOut }
    )(DefaultNavbar);
