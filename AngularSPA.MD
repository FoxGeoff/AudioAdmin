# AudioAdmin.SPA #

## Reference

## Generate initial project Ref: 2.7.1##
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
1. Generate the components
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

