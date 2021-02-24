import React from 'react';
import { Link } from 'react-router-dom';
import { Nav, NavItem, Navbar, NavbarBrand, Container } from 'reactstrap';

export const Navigation = () => {
    return (
        <Navbar color="dark" dark>
            <Container>
                <NavbarBrand href="/">Notes</NavbarBrand>
                <Nav>
                    <NavItem>
                        <Link className="btn btn-secondary mr-2" to="/">Home</Link>
                    </NavItem>
                    <NavItem>
                        <Link className="btn btn-primary" to="/add">Add Note</Link>
                    </NavItem>
                </Nav>
            </Container>
        </Navbar>
    )
}