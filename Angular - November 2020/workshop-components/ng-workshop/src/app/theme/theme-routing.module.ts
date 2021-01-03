import { NewComponent } from './new/new.component';
import { ThemeComponent } from './theme/theme.component';
import { RouterModule, Routes } from '@angular/router';
import { DetailComponent } from './detail/detail.component';

const routes: Routes = [
    {
        path: 'themes',
        pathMatch: 'full',
        component: ThemeComponent
    },
    {
      path: 'theme/detail/:id',
      component: DetailComponent
    },
    {
      path: 'theme/new',
      component: NewComponent
    }
];

export const ThemeRouterModule = RouterModule.forChild(routes);
