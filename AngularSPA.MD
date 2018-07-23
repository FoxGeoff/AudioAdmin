# AudioAdmin.SPA #

## Reference ##

## Generate initial project Ref: 2.7.1 ##
```
//E:\GitHub2018\AudioAdmin\AudioAdmin.SPA
>ng new AudioAdmin.SPA --prefix nga --routing
```
1. View AudioAdmin.SPA ```ng serve -o```. We are using bootstrap which will be replaced by material.angular.io
1. Bootstrap and popper.js: ```npm i bootstrap jquery popper.js --save-prod```
1. Add bootstrap.min.css to the index.html by adding this to angular.cli.json
*THIS DOES NOT WORK USE FIX BELOW*
```
"styles": [
  "styles.css",
  "../node_modules/bootstrap/dist/css/bootstrap.min.css"
]
*FIX in styles.css*
```
/* You can add global styles to this file, and also import other style files */
@import "../node_modules/bootstrap/dist/css/bootstrap.min.css"
```

```
1. Add to scripts section of angular.cli.json
```
"scripts": [
        "../node_modules/jquery/dist/jquery.min.js",
        "../node_modules/popper.js/dist/umd/popper.min.js",
        "../node_modules/bootstrap/dist/js/bootstrap.min.js"
      ],
```
1. Generate the components Listing 2.16:
```
ng g c home
ng g c carousel
ng g c footer
ng g c navbar
ng g c product-item
ng g c product-detail
ng g c search
ng g c stars
```
1. Generate the Product Service
```
ng g s shared/product
```

1. Listing 2.18. The template of the navbar component (ERROR missing closing " on button)
```
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" [routerLink]="['/']">Audio Impact</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse"
    data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
    aria-expanded="false" aria-label="Toggle navigation">

    <span class=" navbar-toggler-icon "></span>

  </button>

  <div class="collapse navbar-collapse "
    id="navbarSupportedContent ">
    <ul class="navbar-nav mr-auto ">
    <li class="nav-item active ">
      <a class="nav-link " href="# ">Home <span class="sr-only ">(current)</span></a>
    </li>
    <li class="nav-item ">
      <a class="nav-link " href="# ">About</a>
    </li>
    <li class="nav-item dropdown ">
      <a class="nav-link dropdown-toggle " href="# "
         id="navbarDropdown " role="button "
         data-toggle="dropdown " aria-haspopup="true " aria-expanded="false ">
         Services
      </a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown ">
      <a class="dropdown-item " href="# ">Find products</a>
      <a class="dropdown-item " href="# ">Place order</a>
    <div class="dropdown-divider "></div>
      <a class="dropdown-item " href="# ">Pay</a>
    </div>
    </li>
    </ul>
  </div>
</nav>
```
1. Listing 2.19. The template of the search component
```
<form name="searchForm">
  <div class="form-group">
    <label for="productTitle">Product title:</label>
    <input type="text" id="productTitle"
      placeholder="Title" class="form-control">
  </div>
  <div class="form-group">
    <label for="productPrice">Product price:</label>
    <input id="productPrice"
     name="productPrice" type="number" min="0"
     placeholder="Price" class="form-control">
  </div>
  <div class="form-group">
    <label for="productCategory">Product category:</label>
    <select id="productCategory" class="form-control"></select>
  </div>
  <div class="form-group">
    <button type="submit"
    class="btn btn-primary btn-block">Search</button>
  </div>
</form>
```
1. Listing 2.20. The template of the footer component
```
<div class="container">
  <hr>
  <footer>
   <div class="row">
    <div class="col-lg-12">
      <p>Copyright © ngAuction 2018</p>
    </div>
   </div>
  </footer>
</div>
```
1. Listing 2.21. The template of the carousel component
```
<div id="myCarousel" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="http://placehold.it/800x300">
    </div>
  <div class="carousel-item">
    <img class="d-block w-100" src="http://placehold.it/800x300">
  </div>
  <div class="carousel-item">
    <img class="d-block w-100" src="http://placehold.it/800x300">
  </div>
  </div>
  <a class="carousel-control-prev" href="#myCarousel"
   role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#myCarousel"
   role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
```
1. 2.7.8  The Home component
```
<div class="row carousel-holder">
  <div class="col-md-12">
  <nga-carousel></nga-carousel>
  </div>
</div>
<div class="row">
  We'll render several ProductItem components here
</div>
```
1. Listing 2.27. Mapping an empty path to the home component (app-routing.module)
```
const routes: Routes = [
  {
  path: '', component: HomeComponent
  }
];
```
TIP How to set the default intergrated terminal window: 
```
"terminal.integrated.shell.windows": "C:\\Program Files\\Git\\bin\\bash.exe",
OR
"terminal.integrated.shell.windows": "C:\\WINDOWS\\System32\\cmd.exe",
```
# 3 Router basics #
## 3.7  Hands-on: Adding navigation to the online auction ##
```
Listing 3.23. product.service.ts

export class Product {
  constructor(
    public id: number,
    public title: string,
    public price: number,
    public rating: number,
    public description: string,
    public categories: string[]) {
  }
}

export class ProductService {

  getProducts(): Product[] {
    return products.map(p => new Product(p.id, p.title,
      p.price, p.rating, p.description, p.categories));
  }

  getProductById(productId: number): Product {
    return products.find(p => p.id === productId);
  }
}

const products = [
  {
    'id': 0,
    'title': 'First Product',
    'price': 24.99,
    'rating': 4.3,
    'description': 'This is a short description. Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
    'categories': ['electronics', 'hardware']
  },
  {
    'id': 1,
    'title': 'Second Product',
    'price': 64.99,
    'rating': 3.5,
    'description': 'This is a short description. Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
    'categories': ['books']
  }];
  }
```