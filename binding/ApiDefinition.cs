//
// ApiDefinition.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2012 Stephane Delcroix. All Rights Reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.CoreAnimation;

namespace PSTCollectionView {
	[BaseType (typeof (PSTCollectionViewLayout))]
	interface PSTCollectionViewFlowLayout {
		[Export ("minimumLineSpacing")]
		float MinimumLineSpacing { get; set; }

		[Export ("minimumInteritemSpacing")]
		float MinimumInteritemSpacing { get; set; }

		[Export ("itemSize")]
		SizeF ItemSize { get; set; }

		//[Export ("scrollDirection")]
		//PSTCollectionViewScrollDirection ScrollDirection { get; set; }

		[Export ("headerReferenceSize")]
		SizeF HeaderReferenceSize { get; set; }

		[Export ("footerReferenceSize")]
		SizeF FooterReferenceSize { get; set; }

		[Export ("sectionInset")]
		UIEdgeInsets SectionInset { get; set; }
		
		[Export ("scrollDirection")]
		PSTCollectionViewScrollDirection ScrollDirection { get; set; }
			
	}

	[BaseType (typeof (PSTCollectionViewFlowLayout))]
	interface PSUICollectionViewFlowLayout {
	}
		
	[Static]
	interface PSTCollectionElementKindSectionKey {
		[Field("PSTCollectionElementKindSectionHeader", "__Internal")]
		[Static]
		NSString Header { get;}

		[Field("PSTCollectionElementKindSectionFooter", "__Internal")]
		[Static]
		NSString Footer { get;}
	}

	[BaseType (typeof (NSObject))]
	interface PSTCollectionViewLayoutAttributes {
		[Export ("elementKind")]
		string ElementKind { get; set; }

		[Export ("reuseIdentifier")]
		string ReuseIdentifier { get; set; }

		[Export ("frame")]
		RectangleF Frame { get; set; }

		[Export ("center")]
		PointF Center { get; set; }

		[Export ("size")]
		SizeF Size { get; set; }

		[Export ("transform3D")]
		CATransform3D Transform3D { get; set; }

		[Export ("alpha")]
		float Alpha { get; set; }

		[Export ("zIndex")]
		int ZIndex { get; set; }
		
		[Export ("layoutAttributesForCellWithIndexPath:")]
		[Static]
		PSTCollectionViewLayoutAttributes CreateForCell (NSIndexPath indexPath);
	}

	[BaseType (typeof(PSTCollectionViewLayoutAttributes))]
	interface PSUICollectionViewLayoutAttributes {
	}

	[BaseType (typeof (NSObject))]
	interface PSTCollectionViewLayout {
		[Export ("collectionView")]
		PSTCollectionView CollectionView { get; set; }

		[Export ("invalidateLayout")]
		void InvalidateLayout ();

		[Export ("prepareLayout")]
		void PrepareLayout();


		[Export ("collectionViewContentSize")]
		SizeF CollectionViewContentSize { get; }

		[Export ("layoutAttributesForItemAtIndexPath:")]
		PSTCollectionViewLayoutAttributes LayoutAttributesForItem (NSIndexPath indexPath);

		//[Export ("layoutAttributesForElementsInRect:")]
		//PSTCollectionViewLayoutAttributes [] LayoutAttributesForElementsInRect(RectangleF rect);

		[Export ("registerClass:forDecorationViewWithReuseIdentifier:")]
		[Internal]
		void RegisterClassForDecorationView(IntPtr cellClass, NSString reuseIdentifier);

		[Export ("shouldInvalidateLayoutForBoundsChange:")]
		bool ShouldInvalidateLayoutForBoundsChange(RectangleF newBounds);

		[Export ("targetContentOffsetForProposedContentOffset:withScrollingVelocity:")]
		PointF TargetContentOffset (PointF proposedContentOffset, PointF scrollingVelocity);

		[Export ("initialLayoutAttributesForInsertedItemAtIndexPath:")]
		PSTCollectionViewLayoutAttributes InitialLayoutAttributesForInsertedItem (NSIndexPath indexPath);	

		[Export ("finalLayoutAttributesForDeletedItemAtIndexPath:")]
		PSTCollectionViewLayoutAttributes FinalLayoutAttributesForDeletedItem (NSIndexPath itemIndexPath);
	}

	[BaseType (typeof(PSTCollectionViewLayout))]
	interface PSUICollectionViewLayout {
	}

	[BaseType (typeof (UIScrollView))]
	interface PSTCollectionView {
		[Export ("initWithFrame:collectionViewLayout:")]
		PSTCollectionView Constructor (RectangleF frame, PSTCollectionViewLayout layout);

		[Export ("collectionViewLayout")]
		PSTCollectionViewLayout CollectionViewLayout { get; set; }

		[Export ("backgroundView")]
		UIView BackgroundView { get; set; }

		[Export ("registerClass:forCellWithReuseIdentifier:")]
		//[Internal]
		void RegisterClassForCell (IntPtr cellClass, NSString reuseIdentifier);

		[Export ("registerClass:forSupplementaryViewOfKind:withReuseIdentifier:")]
		[Internal]
		void RegisterClassForSupplementaryView (IntPtr viewClass, NSString kind, NSString reuseIdentifier);

		[Wrap ("WeakDataSource")]
		PSTCollectionViewDataSource DataSource { get; set; }

		[Export ("dataSource", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakDelegate")]
		PSTCollectionViewDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }


		[Export ("dequeueReusableCellWithReuseIdentifier:forIndexPath:")]
		NSObject DequeueReusableCell (NSString reuseIdentifier, NSIndexPath indexPath);

		[Export ("dequeueReusableSupplementaryViewOfKind:withReuseIdentifier:forIndexPath:")]
		NSObject DequeueReusableSupplementaryView(NSString kind, NSString reuseIdentifier, NSIndexPath indexPath);
		
		[Export ("cellForItemAtIndexPath:")]
		PSTCollectionViewCell CellForItem (NSIndexPath indexPath);

		[Export ("numberOfSections")]
		int NumberOfSections { get; set; }

		[Export ("numberOfItemsInSection:")]
		int NumberOfItemsInSection (int section);
		
        [ExportAttribute("reloadData")]
        void ReloadData();

        [Export ("insertItemsAtIndexPaths:")]
        void InsertItems(NSIndexPath[] indexPaths);

        [Export ("deleteItemsAtIndexPaths:")]
        void DeleteItems(NSIndexPath[] indexPaths);
    }

	[BaseType (typeof (PSTCollectionView))]
	interface PSUICollectionView {
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface PSTCollectionViewDataSource {
		[Export ("collectionView:numberOfItemsInSection:")]
		[Abstract]
		int GetItemsCount (PSTCollectionView collectionView, int section);

		[Export ("collectionView:cellForItemAtIndexPath:")]
		[Abstract]
		PSTCollectionViewCell GetCell (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("numberOfSectionsInCollectionView:")]
		int NumberOfSections (PSTCollectionView collectionView);

	}

	[BaseType (typeof (PSTCollectionViewDelegate))]
	[Model]
	interface PSTCollectionViewDelegateFlowLayout {
		[Export ("collectionView:layout:sizeForItemAtIndexPath:")]
		SizeF GetSizeForItem (PSTCollectionView collectionView, PSTCollectionViewLayout layout, NSIndexPath indexPath);

		[Export ("collectionView:layout:minimumInteritemSpacingForSectionAtIndex:")]
		float GetMinimumInteritemSpacingForSection (UICollectionView collectionView, UICollectionViewLayout layout, int section);

		[Export ("collectionView:layout:minimumLineSpacingForSectionAtIndex:")]
		float GetMinimumLineSpacingForSection (UICollectionView collectionView, UICollectionViewLayout layout, int section);
		[Export ("collectionView:viewForSupplementaryElementOfKind:atIndexPath:")]
		PSTCollectionReusableView GetViewForSupplementaryElement (PSTCollectionView collectionView, NSString elementKind, NSIndexPath indexPath);
	}
		
	[BaseType (typeof (NSObject))]
	[Model]
	interface PSTCollectionViewDelegate {
		[Export ("collectionView:didHighlightItemAtIndexPath:")]
		void ItemHighlighted (PSTCollectionView collectionView, NSIndexPath indexPath);
		
		[Export ("collectionView:didUnhighlightItemAtIndexPath:")]
		void ItemUnhighlighted (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:shouldHighlightItemAtIndexPath:")]
		bool ShouldHighlightItem (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:shouldShowMenuForItemAtIndexPath:")]
		bool ShouldShowMenu (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:canPerformAction:forItemAtIndexPAth:withSender:")]
		bool CanPerformAction (PSTCollectionView collectionView, Selector action, NSIndexPath indexPath, NSObject sender);

		[Export ("collectionView:performAction:forItemAtIndexPAth:withSender:")]
		void PerformAction (PSTCollectionView collectionView, Selector action, NSIndexPath indexPath, NSObject sender);
	}

	[BaseType (typeof (UIViewController))]
	interface PSTCollectionViewController {
		[Export ("initWithCollectionViewLayout:")]
		PSTCollectionViewController Constructor (PSTCollectionViewLayout layout);

		[Export ("collectionView")]
		PSTCollectionView CollectionView { get; set; }

		[Export ("clearsSelectionOnViewWillAppear")]
		bool ClearsSelectionOnViewWillAppear { get; set; }

		//DataSource logic, doesn't belong here, but works for now
		[Export ("collectionView:numberOfItemsInSection:")]
		int GetItemsCount (PSTCollectionView collectionView, int section);

		[Export ("collectionView:cellForItemAtIndexPath:")]
		PSTCollectionViewCell GetCell (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("numberOfSectionsInCollectionView:")]
		int NumberOfSections (PSTCollectionView collectionView);

		//delegate logic
	//	[Export ("collectionView:layout:sizeForItemAtIndexPath:")]
	//	SizeF GetSizeForItem (PSTCollectionView collectionView, PSTCollectionViewLayout layout, NSIndexPath indexPath);

	//	[Export ("collectionView:layout:minimumInteritemSpacingForSectionAtIndex:")]
	//	float GetMinimumInteritemSpacingForSection (PSTCollectionView collectionView, PSTCollectionViewLayout layout, int section);

	//	[Export ("collectionView:layout:minimumLineSpacingForSectionAtIndex:")]
	//	float GetMinimumLineSpacingForSection (PSTCollectionView collectionView, PSTCollectionViewLayout layout, int section);

		[Export ("collectionView:viewForSupplementaryElementOfKind:atIndexPath:")]
		PSTCollectionReusableView GetViewForSupplementaryElement (PSTCollectionView collectionView, NSString elementKind, NSIndexPath indexPath);
		
		[Export ("collectionView:didHighlightItemAtIndexPath:")]
		void ItemHighlighted (PSTCollectionView collectionView, NSIndexPath indexPath);
		
		[Export ("collectionView:didUnhighlightItemAtIndexPath:")]
		void ItemUnhighlighted (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:shouldHighlightItemAtIndexPath:")]
		bool ShouldHighlightItem (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:shouldShowMenuForItemAtIndexPath:")]
		bool ShouldShowMenu (PSTCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:canPerformAction:forItemAtIndexPAth:withSender:")]
		bool CanPerformAction (PSTCollectionView collectionView, Selector action, NSIndexPath indexPath, NSObject sender);

		[Export ("collectionView:performAction:forItemAtIndexPAth:withSender:")]
		void PerformAction (PSTCollectionView collectionView, Selector action, NSIndexPath indexPath, NSObject sender);
		
		


		
		

			
	
	}

	[BaseType (typeof (PSTCollectionViewController))]
	interface PSUICollectionViewController {
	}
	
	[BaseType (typeof (UIView))]
	interface PSTCollectionReusableView {
		[Export ("reuseIdentifier")]
		string ReuseIdentifier { get; }

		[Export ("prepareForReuse")]
		void PrepareForReuse ();

		[Export ("applyLayoutAttributes:")]
		void ApplyLayoutAttributes (PSTCollectionViewLayoutAttributes layoutAttributes);

		[Export ("willTransitionFormLayout:toLayout:")]
		void WillTransition(PSTCollectionViewLayout fromLayout, PSTCollectionViewLayout toLayout);

		[Export ("didTransitionFromLayout:toLayout:")]
		void DidTransition(PSTCollectionViewLayout fromLayout, PSTCollectionViewLayout toLayout);
	}

	[BaseType (typeof (PSTCollectionReusableView))]
	interface PSTCollectionViewCell {
		[Export ("contentView")]
		UIView ContentView { get; }

		[Export ("isSelected")]
		bool IsSelected { get;[Bind ("selected:")] set; }

		[Export ("isHighlighted")]
		bool IsHighlighted { get; [Bind ("highlighted:")]set; }

		[Export ("backgroundView")]
		UIView BackgroundView { get; set; }

		[Export ("SelectedBackgroundView")]
		UIView SelectedBackgroundView { get; set; }
	}

	[BaseType (typeof (PSTCollectionViewCell))]
	interface PSUICollectionViewCell {
		[Export ("applyLayoutAttributes:")]
		void ApplyLayoutAttributes (PSUICollectionViewLayoutAttributes layoutAttributes);
		
		[Export ("willTransitionFormLayout:toLayout:")]
		void WillTransition(PSUICollectionViewLayout fromLayout, PSUICollectionViewLayout toLayout);
		
		[Export ("didTransitionFromLayout:toLayout:")]
		void DidTransition(PSUICollectionViewLayout fromLayout, PSUICollectionViewLayout toLayout);
	}

}
