import React from 'react';
import { Link } from 'react-router-dom';
import {
    Nav,
    NavItem,
    NavLink,
    Navbar,
    NavbarToggler,
} from './../../../components';

import { LogoThemed } from
    './../../components/LogoThemed/LogoThemed';

export const LayoutNavbar = () => (
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
            <Nav className="ml-auto" pills>

                <strong><a href="#" className="text-dark">Sign In</a></strong>


            </Nav>
        </Navbar>
    </React.Fragment>
);
