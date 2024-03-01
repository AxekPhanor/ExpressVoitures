import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { AnnonceService } from '../../services/annonce.service';
import { Annonce } from '../../models/annonce';


@Component({
  selector: 'app-page-detail-annonce',
  templateUrl: './page-detail-annonce.component.html',
  styleUrl: './page-detail-annonce.component.css'
})
export class PageDetailAnnonceComponent {
  @Input() annonce = new Annonce();
  constructor(
    private annonceService: AnnonceService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.getAnnonce();    
  }

  getAnnonce() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.annonceService.getByIdAvailable(id).subscribe({
      next: (value) => {
        this.annonce = value as Annonce;
      },
      error: (error) => {
        if (error.status == 404) {
          this.router.navigate(['/notfound']);
        }
      }
    });
    
  }
}
