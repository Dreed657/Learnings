import { UserService } from './../../user/user.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateChild, Router, RouterStateSnapshot, UrlTree } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivateChild {

    constructor(
        private userService: UserService,
        private router: Router
        ) {}

    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const isLoggedFromData = childRoute.data.isLogged;
        if (typeof isLoggedFromData === 'boolean' && isLoggedFromData === this.userService.isLogged) {
            return true;
        }
        const url = this.router.url;
        this.router.navigate(['/theme']);
        return false;
    }
}
